using BasicArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicArchitecture.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>();
        }
    }
}