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
                flag = entity.Country.Image,
                Venue = entity.VenueId,
                City = entity.Venue.City
            };
        }

    }
}
