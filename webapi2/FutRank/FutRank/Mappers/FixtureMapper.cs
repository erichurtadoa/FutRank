using FutRank.Dtos;
using FutRank.Models;
using Microsoft.AspNetCore.Http;

namespace FutRank.Mappers
{
    public class FixtureMapper
    {
        public FixtureDto MapFixturetoDto(Fixture entity) {
            return new FixtureDto
            {
                Id = entity.Id,
                Referee = entity.Referee,
                Date = NormalizeDate(entity.Date),
                VenueId = entity.VenueId,
                League = entity.League.Name,
                Season = entity.Season,
                Round = entity.Round,
                HomeTeamId = entity.HomeTeamId,
                LogoHome = entity.HomeClub.Logo,
                AwayTeamId = entity.AwayTeamId,
                LogoAway = entity.AwayClub.Logo,
                GoalsHome = entity.GoalsHome,
                GoalsAway = entity.GoalsAway,
                PenaltyHome = entity.PenaltyHome,
                PenaltyAway = entity.PenaltyAway,
                Rate = entity.Rate
            };
        }

        public FixtureDto MapFixturetoDtoUser(Fixture entity, Guid userId)
        {
            return new FixtureDto
            {
                Id = entity.Id,
                Referee = entity.Referee,
                Date = NormalizeDate(entity.Date),
                VenueId = entity.VenueId,
                League = entity.League.Name,
                Season = entity.Season,
                Round = entity.Round,
                HomeTeamId = entity.HomeTeamId,
                LogoHome = entity.HomeClub.Logo,
                AwayTeamId = entity.AwayTeamId,
                LogoAway = entity.AwayClub.Logo,
                GoalsHome = entity.GoalsHome,
                GoalsAway = entity.GoalsAway,
                PenaltyHome = entity.PenaltyHome,
                PenaltyAway = entity.PenaltyAway,
                Rate = entity.Rate,
                UserNote = entity.UserFixtures.Where(x => x.UserId == userId).FirstOrDefault()?.UserNote
            };
        }

        public FixtureDetailsDto MapFixturetoDetailsDto(Fixture entity, Guid userId)
        {
            return new FixtureDetailsDto
            {
                Id = entity.Id,
                Referee = entity.Referee,
                Date = NormalizeDate(entity.Date),
                VenueName = entity.Venue.Name,
                VenueImage = entity.Venue.Image,
                League = entity.League.Name,
                Season = entity.Season,
                Round = entity.Round,
                HomeTeamName = entity.HomeClub.Name,
                LogoHome = entity.HomeClub.Logo,
                AwayTeamName = entity.AwayClub.Name,
                LogoAway = entity.AwayClub.Logo,
                GoalsHome = entity.GoalsHome,
                GoalsAway = entity.GoalsAway,
                PenaltyHome = entity.PenaltyHome,
                PenaltyAway = entity.PenaltyAway,
                Rate = entity.Rate,
                UserNote = entity.UserFixtures.Where(x => x.UserId == userId).FirstOrDefault()?.UserNote
            };
        }

        private string NormalizeDate(string date)
        {
            return date.Split('T')[0];
        }

    }
}
