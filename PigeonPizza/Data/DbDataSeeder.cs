using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Basics;
using System.Linq;
using System.Collections.Generic;
using PigeonPizza.Models.Complex;

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
                    context.Scales.AddRange(new PizzaScale[]
                    {
                        new PizzaScale("Small", 16M),
                        new PizzaScale("Normal", 24M),
                        new PizzaScale("Large", 36M),
                    });
                }
                // Doughs
                if (!context.Doughs.Any())
                {
                    context.Doughs.AddRange(new PizzaDough[]
                    {
                        new PizzaDough("White", 45M),
                        new PizzaDough("Wheat", 60M),
                    });
                }
                // Other
                if (!context.Basics.Any())
                {
                    context.Basics.AddRange(new PizzaBasic[]
                    {
                        // Works
                        new PizzaBasic(PizzaBasicType.Work, "Cut", 0.1M),
                        new PizzaBasic(PizzaBasicType.Work, "Bake", 3.7M),
                        // Sauces
                        new PizzaBasic(PizzaBasicType.Sauce, "Ketchup", 25.6M),
                        new PizzaBasic(PizzaBasicType.Sauce, "Mayotchup", 35.5M),
                        new PizzaBasic(PizzaBasicType.Sauce, "Barbecue", 20.4M),
                        new PizzaBasic(PizzaBasicType.Sauce, "Pesto", 40.0M),
                        // Bases
                        new PizzaBasic(PizzaBasicType.Base, "Mozzarella", 80.3M),
                        new PizzaBasic(PizzaBasicType.Base, "Hard cheese", 60.2M),
                        new PizzaBasic(PizzaBasicType.Base, "Aged cheeze", 120.1M),
                        // Toppings meat
                        new PizzaBasic(PizzaBasicType.Topping, "Pepperoni", 150.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Sausage", 125.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Bacon", 150.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Salami", 140.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Chicken", 110.0M),
                        // Toppings plants
                        new PizzaBasic(PizzaBasicType.Topping, "Sweet pepper", 60.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Olives", 70.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Mushrooms", 50.0M),
                        new PizzaBasic(PizzaBasicType.Topping, "Pineapple", 80.0M),
                        // Toppings fish
                        new PizzaBasic(PizzaBasicType.Topping, "Fish", 90.0M),
                        // Spices
                        new PizzaBasic(PizzaBasicType.Spice, "Basil", 5.0M),
                        new PizzaBasic(PizzaBasicType.Spice, "Oregano", 8.0M),
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

                var toAdd = new List<PizzaRecipe>();

                toAdd.Add(
                    new PizzaRecipe.Builder()
                    .SetScale(context.Scales.FirstOrDefault(x => x.Name == "Normal"))
                    .SetDough(context.Doughs.FirstOrDefault(x => x.Name == "White"))
                    .AddBasic(context.Basics.FirstOrDefault(x => x.Name == "Ketchup"), 1)
                    .AddBasic(context.Basics.FirstOrDefault(x => x.Name == "Mozzarella"), 2)
                    .AddBasic(context.Basics.FirstOrDefault(x => x.Name == "Pepperoni"), 2)
                    .Publish("Pepperoni pizza", "White-dough-based normal-scaled pizza")
                    .Build());

                foreach (var item in toAdd)
                {
                    for (int i = 0; i < item.Tasks.Count; i++)
                    {
                        // load all of elementary tasks to the db
                        var task = (item.Tasks as IList<BasicsTask>)[i];
                        (item.Tasks as IList<BasicsTask>)[i] = context.BasicsTasks.Add(task).Entity;
                    }

                    if (item.Publish != null)
                    {
                        context.PublishReceipes.Add(item.Publish);
                    }

                    context.PizzaRecipes.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
