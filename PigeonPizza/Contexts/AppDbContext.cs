using Microsoft.EntityFrameworkCore;

namespace PigeonPizza.Contexts
{
    public class AppDbContext: DbContext
    {
        #region Tables
        DbSet<string> Example { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
