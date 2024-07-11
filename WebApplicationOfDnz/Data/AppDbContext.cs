using Microsoft.EntityFrameworkCore;
using WebApplicationOfDnz.Data.Entities;

namespace WebApplicationOfDnz.Data
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Users> Users2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server =.;Database = ApiDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
