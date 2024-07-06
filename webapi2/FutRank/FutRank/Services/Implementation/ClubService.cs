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

        public ClubService(IClubRepository clubRepository, ClubMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClubDto> GetClubsAsync()
        {
            var clubs = _clubRepository.GetClubsAsync();
            return clubs.Select(c => _mapper.MapClubtoDto(c));
        }

        public IEnumerable<ClubDto> GetClubsUserAsync(Guid userId)
        {
            var clubs = _clubRepository.GetClubsAsync();
            return clubs.Select(c => _mapper.MapClubtoDtoUser(c, userId));
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
