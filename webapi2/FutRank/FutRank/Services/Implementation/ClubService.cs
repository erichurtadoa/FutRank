using FutRank.Dtos;
using FutRank.Mappers;
using FutRank.Models;
using FutRank.Repositories.Interfaces;
using FutRank.Services.Interfaces;

namespace FutRank.Services.Implementation
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly ClubMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ClubService(IClubRepository clubRepository, ClubMapper mapper, IUserRepository userRepository)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public IEnumerable<ClubDto> GetClubsAsync(ClubFilter filter)
        {
            var clubs = _clubRepository.GetClubsAsync(filter);
            return clubs.Select(c => _mapper.MapClubtoDto(c));
        }

        public IEnumerable<ClubDto> GetClubsUserAsync(Guid userId, ClubFilter filter)
        {
            var clubs = _clubRepository.GetClubsAsync(filter);
            return clubs.Select(c => _mapper.MapClubtoDtoUser(c, userId));
        }

        public async Task<IEnumerable<ClubDto>> GetOnlyClubsUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserDetailsAsync(userId);
            var userClubs = user.UserClubs.Select(x => x.Club);
            var userClubsDto = userClubs.Select(c => _mapper.MapClubtoDtoUser(c, userId)).Where(x => x.Upvote != null);
            return userClubsDto.OrderByDescending(u => u.Popularity);
        }

        public ClubDetailsDto GetClubByIdAsync(int id)
        {
            var club = _clubRepository.GetClubById(id);
            return _mapper.MapClubtoDetailsDto(club);
        }

        public async Task VoteClub(bool upVote, Guid userId, int clubId)
        {
            var userClub = new UserClubs
            {
                UserId = userId,
                ClubId = clubId,
                UpVote = upVote,
            };

            await _clubRepository.VoteClubAsync(userClub);

            await _clubRepository.UpdateClubPopularityAsync(clubId);
        }

        public async Task AddFavourite(Guid userId, int clubId)
        {
            var userClub = new UserClubs
            {
                UserId = userId,
                ClubId = clubId
            };

            await _clubRepository.AddFavourite(userClub);
        }
    }
}
