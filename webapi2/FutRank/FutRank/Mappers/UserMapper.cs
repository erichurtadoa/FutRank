using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Mappers
{
    public class UserMapper
    {
        public UserDetailsDto MapUserToDto(UserInfo entity) {
            return new UserDetailsDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Name = entity.Name,
                DateSignUp = entity.DateSignUp,
                FixtureTime = entity.FixtureTime
            };
        }
    }
}
