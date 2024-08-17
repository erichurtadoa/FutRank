using FutRank.Dtos;
using FutRank.Models;
using FutRank.Services.Implementation;
using FutRank.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FutRank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly SampleDBContext _context;
        private readonly IUserService _userService;

        public SessionController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration, 
            SampleDBContext context, 
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email already in use.");
                    return BadRequest(ModelState);
                }

                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userInfo = new UserInfo
                    {
                        Id = new Guid(user.Id),
                        Username = user.UserName,
                        Email = user.Email,
                        DateSignUp = DateTime.Now.ToString()
                    };
                    _context.UsersInfo.Add(userInfo);
                    _context.SaveChanges();

                    return Ok(new { Result = "User created successfully" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    var token = GenerateJwtToken(user);
                    return Ok(new { Id = user.Id, Username = user.UserName, Email = user.Email, Token = token });
                }

                return Unauthorized();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("User")]
        [Authorize]
        public async Task<UserDetailsDto> GetUserDetails()
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);

            var userGuid = new Guid(userId);

            return await _userService.GetUserDetailsAsync(userGuid);
        }

        [HttpGet("User/{username}")]
        public async Task<UserDetailsDto> GetUserDetailsByUsername(string username)
        {
            var userId = _context.UsersInfo.Where(u => u.Username == username).Select(u => u.Id).FirstOrDefault();

            return await _userService.GetUserDetailsAsync(userId);
        }

        [HttpPost("Set")]
        [Authorize]
        public IActionResult SetDate()
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);
            var userGuid = new Guid(userId);
            var userInfo = _context.UsersInfo.Where(x => x.Id == userGuid).FirstOrDefault();
            userInfo.DateSignUp = DateTime.Now.ToString();
            _context.SaveChanges();
            return Ok();

        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Sid, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
