using Microsoft.EntityFrameworkCore;
using PigeonPizza.Models.Basics;
using PigeonPizza.Models.Complex;
using PigeonPizza.Models.Control;

namespace PigeonPizza.Contexts
{
    public class AppDbContext: DbContext
    {
        #region Tables
        public DbSet<PizzaBasic> Basics { get; set; }
        public DbSet<PizzaDough> Doughs { get; set; }
        public DbSet<PizzaScale> Scales { get; set; }
        public DbSet<BasicsTask> BasicsTasks { get; set; }
        public DbSet<PublishRecipe> PublishReceipes { get; set; }
        public DbSet<PizzaRecipe> PizzaRecipes { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaDough>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaBasic>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaScale>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PublishRecipe>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }

        public DbSet<PigeonPizza.Models.Control.User> User { get; set; }

        public DbSet<PigeonPizza.Models.Control.Order> Order { get; set; }
    }
}
