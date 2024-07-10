using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Models;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FutRank.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ClubMapper _clubMapper;
        private readonly UserMapper _userMapper;

        public UserService(IUserRepository userRepository, ClubMapper clubMapper, UserMapper userMapper) 
        {
            _userRepository = userRepository;
            _clubMapper = clubMapper;
            _userMapper = userMapper;
        }

        public async Task<UserDetailsDto> GetUserDetailsAsync(Guid userId)
        {
            var user = await _userRepository.GetUserDetailsAsync(userId);
            var userDto = _userMapper.MapUserToDto(user);
            userDto.FavouriteClub = _clubMapper.MapClubtoDto(user.FavouriteClub);
            return userDto;
        }
    }
}
