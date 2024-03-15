using Microsoft.EntityFrameworkCore;
using RegApp.Models;

namespace RegApp.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
          : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");

        }

    }
}
