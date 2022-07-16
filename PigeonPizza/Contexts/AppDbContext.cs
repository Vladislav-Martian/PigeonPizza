using Microsoft.EntityFrameworkCore;
using PigeonPizza.Models.Basics;
using PigeonPizza.Models.Complex;

namespace PigeonPizza.Contexts
{
    public class AppDbContext: DbContext
    {
        #region Tables
        public DbSet<PizzaBasicsCover> Covers { get; set; }
        public DbSet<PizzaBasicsTopping> Toppings { get; set; }
        public DbSet<PizzaBasicsDough> Doughs { get; set; }
        public DbSet<PizzaBasicsWork> Works { get; set; }
        public DbSet<PizzaBasicsScale> Scales { get; set; }
        public DbSet<PizzaOfficialRecipe> OfficialRecipes { get; set; }
        public DbSet<PizzaCustomRecipe> CustomRecipes { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaBasicsCover>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaBasicsTopping>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaBasicsDough>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaBasicsWork>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<PizzaBasicsScale>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
