using Microsoft.EntityFrameworkCore;
using SADIG_API.Domain.Entities;

namespace SADIG_API.Infrastructure.Persistence
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        //Database tables
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Cat_Users");
            modelBuilder.Entity<User>().HasKey(u => u.PKUser);
        }
    }
}
