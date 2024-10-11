using Microsoft.EntityFrameworkCore;
using pruebaEdwin.Models;

namespace pruebaEdwin.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
               .HasIndex(u => u.Document)
               .IsUnique();

        }
    }
}
