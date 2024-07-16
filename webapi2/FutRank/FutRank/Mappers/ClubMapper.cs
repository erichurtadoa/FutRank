using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Mappers
{
    public class ClubMapper
    {
        public ClubDto MapClubtoDto(Club entity) {
            return new ClubDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Founded = entity.Founded,
                National = entity.National,
                Logo = entity.Logo,
                Popularity = entity.Popularity,
                Country = entity.CountryName,
                Flag = entity.Country?.Image,
                Venue = entity.VenueId,
                City = entity.Venue?.City
            };
        }

        public ClubDto MapClubtoDtoUser(Club entity, Guid userId)
        {
            return new ClubDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Founded = entity.Founded,
                National = entity.National,
                Logo = entity.Logo,
                Popularity = entity.Popularity,
                Country = entity.CountryName,
                Flag = entity.Country?.Image,
                Venue = entity.VenueId,
                City = entity.Venue?.City,
                Favourite = entity.UserClubs.Where(x => x.UserId == userId).FirstOrDefault()?.Favourite,
                Upvote = entity.UserClubs.Where(x => x.UserId == userId).FirstOrDefault()?.UpVote
            };
        }

        public ClubDetailsDto MapClubtoDetailsDto(Club entity)
        {
            return new ClubDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Founded = entity.Founded,
                National = entity.National,
                Logo = entity.Logo,
                Popularity = entity.Popularity,
                Country = entity.CountryName,
                flag = entity.Country?.Image,
                VenueName = entity.Venue?.Name,
                VenueAddress = entity.Venue?.Address,
                VenueCapacity = entity.Venue?.Capacity,
                VenueSurface = entity.Venue?.Surface,
                VenueImage = entity.Venue?.Image,
                VenueCity = entity.Venue?.City
            };
        }
    }
}
