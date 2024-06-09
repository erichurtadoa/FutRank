using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Models;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ClubMapper _mapper;

        public SessionService(ISessionRepository sessionRepository, ClubMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public User RegisterUser(RegisterDto registerRequest)
        {
            var user = new User
            {
                Email = registerRequest.Email,
                //Username = registerRequest.Username,
                Password = registerRequest.Password,
            };

            _sessionRepository.AddUser(user);

            return user;
        }
    }
}
