using Microsoft.EntityFrameworkCore;
using PostManagement.Configurations;
using PostManagement.Models;

namespace PostManagement.DataAccess
{
    public class PostManagementDB : DbContext
    {
        public PostManagementDB(DbContextOptions<PostManagementDB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfigurations());
            modelBuilder.ApplyConfiguration(new PostCategoryConfigurations());
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
        }

        #region Entity
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        #endregion
    }
}
