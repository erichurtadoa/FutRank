using FutRank.Dtos;
using FutRank.Models;

namespace FutRank.Mappers
{
    public class FixtureMapper
    {
        public FixtureDto MapFixturetoDto(Fixture entity) {
            return new FixtureDto
            {
                Id = entity.Id,
                Referee = entity.Referee,
                Date = entity.Date,
                VenueId = entity.VenueId,
                League = entity.League.Name,
                Season = entity.Season,
                Round = entity.Round,
                HomeTeamId = entity.HomeTeamId,
                AwayTeamId = entity.AwayTeamId,
                GoalsHome = entity.GoalsHome,
                GoalsAway = entity.GoalsAway,
                PenaltyHome = entity.PenaltyHome,
                PenaltyAway = entity.PenaltyAway,
                Rate = entity.Rate,
            };
        }

    }
}
