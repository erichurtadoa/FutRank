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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>(entity => {
                entity.HasKey(k => k.Id);
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Club>(entity => {
                entity.HasKey(k => k.Id);
                entity.HasOne(c => c.Venue)
                .WithMany()
                .HasForeignKey(c => c.VenueId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
