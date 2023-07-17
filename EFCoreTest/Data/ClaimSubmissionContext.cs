using EFCoreTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.Data
{
    public class ClaimSubmissionContext : DbContext
    {
        public ClaimSubmissionContext(DbContextOptions<ClaimSubmissionContext> options) : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimDefendentLink> ClaimDefendentLinks { get; set; }
        public DbSet<ClaimPlaintiffLink> ClaimPlaintiffLinks { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Defendent> Defendents { get; set; }
        public DbSet<Filer> Filers { get; set; }
        public DbSet<FilerAssociation> FilerAssociations { get; set; }
        public DbSet<FilerType> FilerTypes { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Plaintiff> Plaintiffs { get; set; }
        public DbSet<QueueStatus> QueueStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>().ToTable("Claim");
            modelBuilder.Entity<ClaimDefendentLink>().ToTable("ClaimDefendentLink");
            modelBuilder.Entity<ClaimPlaintiffLink>().ToTable("ClaimPlaintiffLink");
            modelBuilder.Entity<County>().ToTable("County");
            modelBuilder.Entity<Defendent>().ToTable("Defendent");
            modelBuilder.Entity<Filer>().ToTable("Filer");
            modelBuilder.Entity<FilerAssociation>(entity =>
            {
                entity
                    .HasOne(f => f.Filer)
                    .WithMany(a => a.FilerAssociationsAsFiler)
                    .HasForeignKey(k => k.FilerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasOne(f => f.Association)
                    .WithMany(a => a.FilerAssociationsAsAssociation)
                    .HasForeignKey(k => k.AssociationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<FilerType>().ToTable("FilerType");
            modelBuilder.Entity<Firm>().ToTable("Firm");
            modelBuilder.Entity<Plaintiff>().ToTable("Plaintiff");
            modelBuilder.Entity<QueueStatus>().ToTable("QueueStatus");
        }
    }
}
