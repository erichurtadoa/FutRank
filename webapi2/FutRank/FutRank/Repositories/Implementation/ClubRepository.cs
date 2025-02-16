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

        public IEnumerable<Club> GetClubsAsync(ClubFilter filter)
        {
            var query =  _context.Clubs
                .Include(club => club.Venue)
                .Include(club => club.Country)
                .Include(club => club.UserClubs)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Team))
            {
                query = query.Where(f => f.Name.Contains(filter.Team));
            }

            if (!string.IsNullOrEmpty(filter.Country))
            {
                query = query.Where(f => f.Country.Name.Contains(filter.Country));
            }

            return query.ToList().OrderByDescending(club => club.Popularity);
        }

        public Club GetClubById(int id)
        {
            var club = _context.Clubs
                .Include(club => club.Venue)
                .Include(club => club.Country)
                .Include(club => club.UserClubs)
                .Include(club => club.Standings)
                    .ThenInclude(standing => standing.League)
                .Where(club => club.Id == id)
                .FirstOrDefault();
            return club;
        }

        public async Task VoteClubAsync(UserClubs userClubs)
        {
            var existedUser = await _context.UserClubs.Where(x => x.UserId == userClubs.UserId && x.ClubId == userClubs.ClubId).FirstOrDefaultAsync();
            
            if (existedUser != null)
            {
                if (existedUser.UpVote == userClubs.UpVote)
                {
                    existedUser.UpVote = null;

                    if (existedUser.Favourite == null)
                        _context.UserClubs.Remove(existedUser);
                }

                else 
                    existedUser.UpVote = userClubs.UpVote;
            }

            else
            {
                _context.UserClubs.Add(userClubs);
            }

            _context.SaveChanges();
        }

        public async Task UpdateClubPopularityAsync(int clubId)
        {
            var upVotes = await _context.UserClubs
            .Where(uc => uc.ClubId == clubId && uc.UpVote == true)
            .CountAsync();

            var downVotes = await _context.UserClubs
                .Where(uc => uc.ClubId == clubId && uc.UpVote == false)
                .CountAsync();

            var popularity = upVotes - downVotes;

            var club = await _context.Clubs.FirstOrDefaultAsync(c => c.Id == clubId);
            if (club != null)
            {
                club.Popularity = popularity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddFavourite(UserClubs userClubs)
        {
            if (await _context.UserClubs.Where(x => x.UserId == userClubs.UserId && x.Favourite && x.ClubId != userClubs.ClubId).FirstOrDefaultAsync() != null)
            {
                throw new Exception("you already have a favourite club");
            }

            var existedUser = await _context.UserClubs.Where(x => x.UserId == userClubs.UserId && x.ClubId == userClubs.ClubId).FirstOrDefaultAsync();
            var user = await _context.UsersInfo.Where(x => x.Id == userClubs.UserId).FirstOrDefaultAsync();

            if (existedUser != null)
            {
                existedUser.Favourite = !existedUser.Favourite;
                if (existedUser.Favourite)
                    user.FavouriteClubId = userClubs.ClubId;
                else
                    user.FavouriteClubId = null;
            }

            else
            {
                userClubs.Favourite = true;
                _context.UserClubs.Add(userClubs);
                user.FavouriteClubId = userClubs.ClubId;
            }

            _context.SaveChanges();
        }
    }
}
