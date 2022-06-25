using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigeonPizza.Contexts;
using System.Linq;

namespace PigeonPizza.Data
{
    public class DbDataSeeder
    {
        public static void SeedPrimitives(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                #region Actual seeding
                // Bases
                if (!context.PizzaBases.Any())
                {

                }
                // Dough
                if (!context.PizzaDoughs.Any())
                {

                }
                // Process
                if (!context.PizzaProcesses.Any())
                {

                }
                // Sauce
                if (!context.PizzaSauces.Any())
                {

                }
                // Sizes
                if (!context.PizzaSizes.Any())
                {

                }
                // Spices
                if (!context.PizzaSpices.Any())
                {

                }
                // Toppings
                if (!context.PizzaToppings.Any())
                {

                }
                #endregion

                context.SaveChanges();
            }
        }
        public static void SeedTemplates(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                #region Actual seeding
                // Complex Templates
                if (!context.PizzaComplexTemplates.Any())
                {

                }
                // Order Templates
                if (!context.OrderTemplates.Any())
                {

                }
                #endregion

                context.SaveChanges();
            }
        }
    }
}
