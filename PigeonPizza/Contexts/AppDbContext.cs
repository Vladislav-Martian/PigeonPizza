using Microsoft.EntityFrameworkCore;
using PigeonPizza.Models.Controls;
using PigeonPizza.Models.Orders;
using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Contexts
{
    public class AppDbContext: DbContext
    {
        #region Tables
        #region Primitive
        public DbSet<PizzaBase> PizzaBases { get; set; }
        public DbSet<PizzaDough> PizzaDoughs { get; set; }
        public DbSet<PizzaProcess> PizzaProcesses { get; set; }
        public DbSet<PizzaSauce> PizzaSauces { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<PizzaSpice> PizzaSpices { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }
        #endregion
        #region Orders
        public DbSet<PizzaBaseOrder> PizzaBaseOrders { get; set; }
        public DbSet<PizzaComplexOrder> PizzaComplexOrders { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<PizzaSauceOrder> PizzaSauceOrders { get; set; }
        public DbSet<PizzaSauceOrder> PizzaSpiceOrders { get; set; }
        public DbSet<PizzaToppingOrder> PizzaToppingOrders { get; set; }
        #endregion
        #region Controls
        public DbSet<ApprovedOrder> ApprovedOrders { get; set; }
        public DbSet<OrderTemplate> OrderTemplates { get; set; }
        public DbSet<QueuedOrder> QueuedOrders { get; set; }
        public DbSet<RejectedOrder> RejectedOrders { get; set; }
        public DbSet<UserDiscount> UserDiscounts { get; set; }
        public DbSet<UserSavedOrderTemplates> UserSavedOrderTemplates { get; set; }
        #endregion
        #region Other
        #endregion
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
