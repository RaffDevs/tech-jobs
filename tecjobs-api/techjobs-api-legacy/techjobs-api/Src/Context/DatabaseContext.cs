using Microsoft.EntityFrameworkCore;
using techjobs_api.Src.Entities;

namespace techjobs_api.Src.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }

        public DbSet<Employment> Employments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employment>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employments)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
