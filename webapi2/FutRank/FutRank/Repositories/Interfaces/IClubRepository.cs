﻿using FutRank.Models;

namespace FutRank.Repositories.Interfaces
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetClubsAsync();
        Club GetClubById(int Id);
    }
}
