using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Services.Interfaces
{
    public interface ISessionService
    {
        User RegisterUser(RegisterDto registerRequest);
    }
}
