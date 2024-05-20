﻿using FutRank.Models;
using FutRank.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FutRank.Repositories.Implementation
{
    public class ClubRepository : IClubRepository
    {
        private readonly SampleDBContext _context;

        public ClubRepository(SampleDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Club> GetClubsAsync()
        {
            var clubs =  _context.Clubs.Include(club => club.Venue)
                .Include(club => club.Country)
                .ToList();
            return clubs;
        }

        public Club GetClubById(int id)
        {
            var club = _context.Clubs.Include(club => club.Venue)
                .Include(club => club.Country)
                .Where(club => club.Id == id)
                .FirstOrDefault();
            return club;
        }
    }
}
