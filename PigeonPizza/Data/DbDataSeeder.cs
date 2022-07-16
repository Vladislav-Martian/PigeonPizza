using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Basics;
//using PigeonPizza.Models.Complex;
//using PigeonPizza.Models.Controls;
using System.Linq;
using System.Collections.Generic;

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
                // Scales
                if (!context.Scales.Any())
                {
                    context.Scales.AddRange(new PizzaBasicsScale[]
                    {
                        new PizzaBasicsScale("Small", 16M),
                        new PizzaBasicsScale("Normal", 24M),
                        new PizzaBasicsScale("Large", 36M),
                    });
                }
                // Doughs
                if (!context.Doughs.Any())
                {
                    context.Doughs.AddRange(new PizzaBasicsDough[]
                    {
                        new PizzaBasicsDough("White", 3M),
                        new PizzaBasicsDough("Wheat", 4M),
                    });
                }
                // Works
                if (!context.Works.Any())
                {
                    context.Works.AddRange(new PizzaBasicsWork[]
                    {
                        new PizzaBasicsWork("Cut", 0.1M),
                        new PizzaBasicsWork("Bake", 3M),
                    });
                }
                // Covers
                if (!context.Covers.Any())
                {
                    context.Covers.AddRange(new PizzaBasicsCover[]
                    {
                        new PizzaBasicsCover("Tomato Sauce", 1.1M),
                        new PizzaBasicsCover("Ketchup", 1.3M),
                        new PizzaBasicsCover("Mayotchup", 1.5M),
                        new PizzaBasicsCover("Cheese", 2.4M),
                    });
                }
                // Toppings
                if (!context.Toppings.Any())
                {
                    context.Toppings.AddRange(new PizzaBasicsTopping[]
                    {
                        new PizzaBasicsTopping("Pepperoni", 4.0M),
                        new PizzaBasicsTopping("Sausages", 3.3M),
                        new PizzaBasicsTopping("Meat", 4.2M),
                        new PizzaBasicsTopping("Salad", 1.6M),
                    });
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
                
                context.SaveChanges();
            }
        }
    }
}
