using Microsoft.EntityFrameworkCore;

namespace FutRank.Models
{
    public partial class SampleDBContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(v => v.Country)
                .WithMany()
                .HasForeignKey(v => v.CountryName);
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Club>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(c => c.Venue)
                .WithMany()
                .HasForeignKey(c => c.VenueId);
                entity.HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryName);
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Country>(entity => {
                entity.HasKey(k => k.Name);
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<League>(entity => {
                entity.HasKey(k => new { k.Id, k.SeasonYear });
                entity.HasOne(v => v.Country)
                .WithMany()
                .HasForeignKey(v => v.CountryName);
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Standing>(entity => {
                entity.HasKey(k => new { k.LeagueId, k.Season, k.ClubId });
                entity.HasOne(v => v.League)
                .WithMany(l => l.Standings)
                .HasForeignKey(v => new { v.LeagueId, v.Season });
                entity.HasOne(v => v.Club)
                .WithMany(c => c.Standings)
                .HasForeignKey(v => v.ClubId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
