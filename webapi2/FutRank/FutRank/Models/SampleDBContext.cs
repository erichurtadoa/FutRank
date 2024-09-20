using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutRank.Models
{
    public partial class SampleDBContext : IdentityDbContext<IdentityUser>
    {
        public SampleDBContext(DbContextOptions
        <SampleDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Standing> Standings { get; set; }
        public virtual DbSet<Fixture> Fixture { get; set; }
        public virtual DbSet<UserClubs> UserClubs { get; set; }
        public virtual DbSet<UserInfo> UsersInfo { get; set; }
        public virtual DbSet<UserFixtures> UserFixtures { get; set; }
        public virtual DbSet<ForumThread> ForumThread {  get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CommentFixture> CommentFixture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venue>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.Country)
                .WithMany()
                .HasForeignKey(v => v.CountryName);
            });

            modelBuilder.Entity<Club>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(c => c.Venue)
                .WithMany()
                .HasForeignKey(c => c.VenueId);
                entity.HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryName);
            });

            modelBuilder.Entity<Country>(entity => {
                entity.HasKey(k => k.Name);
            });

            modelBuilder.Entity<League>(entity => {
                entity.HasKey(k => new { k.Id, k.SeasonYear });
                entity.HasOne(v => v.Country)
                .WithMany()
                .HasForeignKey(v => v.CountryName);
            });

            modelBuilder.Entity<Standing>(entity => {
                entity.HasKey(k => new { k.LeagueId, k.Season, k.ClubId });
                entity.HasOne(v => v.League)
                .WithMany(l => l.Standings)
                .HasForeignKey(v => new { v.LeagueId, v.Season });
                entity.HasOne(v => v.Club)
                .WithMany(c => c.Standings)
                .HasForeignKey(v => v.ClubId);
            });

            modelBuilder.Entity<Fixture>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.League)
                .WithMany(l => l.Fixtures)
                .HasForeignKey(v => new { v.LeagueId, v.Season });
                entity.HasOne(v => v.HomeClub)
                .WithMany(c => c.HomeFixtures)
                .HasForeignKey(v => v.HomeTeamId);
                entity.HasOne(v => v.AwayClub)
                .WithMany(c => c.AwayFixtures)
                .HasForeignKey(v => v.AwayTeamId);
                entity.HasOne(v => v.Venue)
                .WithMany()
                .HasForeignKey(v => v.VenueId);
            });

            modelBuilder.Entity<UserClubs>(entity => {
                entity.HasKey(k => new { k.UserId, k.ClubId });
                entity.HasOne(v => v.Club)
                .WithMany(c => c.UserClubs)
                .HasForeignKey(v => v.ClubId);
                entity.HasOne(v => v.User)
                .WithMany(c => c.UserClubs)
                .HasForeignKey(v => v.UserId);
            });

            modelBuilder.Entity<UserInfo>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.FavouriteClub)
                .WithMany()
                .HasForeignKey(v => v.FavouriteClubId);
            });

            modelBuilder.Entity<UserFixtures>(entity => {
                entity.HasKey(k => new { k.UserId, k.FixtureId });
                entity.HasOne(v => v.Fixture)
                .WithMany(c => c.UserFixtures)
                .HasForeignKey(v => v.FixtureId);
                entity.HasOne(v => v.User)
                .WithMany(c => c.UserFixtures)
                .HasForeignKey(v => v.UserId);
            });

            modelBuilder.Entity<ForumThread>(entity => {
                entity.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Comment>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.ForumThread)
                .WithMany(c => c.Comments)
                .HasForeignKey(v => v.ForumThreadId);
            });

            modelBuilder.Entity<CommentFixture>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.Fixture)
                .WithMany(c => c.Comments)
                .HasForeignKey(v => v.FixtureId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
