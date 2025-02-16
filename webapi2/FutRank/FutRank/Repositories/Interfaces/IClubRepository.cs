﻿using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetClubsAsync(ClubFilter filter);
        Club GetClubById(int Id);
        Task VoteClubAsync(UserClubs userClub);
        Task UpdateClubPopularityAsync(int clubId);
        Task AddFavourite(UserClubs userClubs);
    }
}
