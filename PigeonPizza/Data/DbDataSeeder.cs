using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Primitive;
using PigeonPizza.Models.Other;
using PigeonPizza.Models.Orders;
using PigeonPizza.Models.Controls;
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
                    context.PizzaBases.AddRange(new PizzaBase[]
                    {
                        new PizzaBase()
                        {
                            Id = 0,
                            Name = "Mozzarella",
                            Description = "",
                            Available = true,
                            PriceAddition = 250,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
                            Id = 1,
                            Name = "Parmesan",
                            Description = "",
                            Available = true,
                            PriceAddition = 230,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
                            Id = 2,
                            Name = "Cheddar",
                            Description = "",
                            Available = true,
                            PriceAddition = 290,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
                            Id = 3,
                            Name = "Sweeden Emmental",
                            Description = "",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 1
                        }
                    });
                }
                // Dough
                if (!context.PizzaDoughs.Any())
                {
                    context.PizzaDoughs.AddRange(new PizzaDough[]
                    {
                        new PizzaDough()
                        {
                            Id = 0,
                            Name = "Wheat",
                            Description = "",
                            Available = true,
                            PriceAddition = 50,
                            PriceModifier = 1
                        },
                        new PizzaDough()
                        {
                            Id = 1,
                            Name = "Puff paste",
                            Description = "",
                            Available = true,
                            PriceAddition = 60,
                            PriceModifier = 1
                        },
                        new PizzaDough()
                        {
                            Id = 2,
                            Name = "Yeast free",
                            Description = "",
                            Available = true,
                            PriceAddition = 70,
                            PriceModifier = 1
                        }
                    });
                }
                // Process
                if (!context.PizzaProcesses.Any())
                {
                    context.PizzaProcesses.AddRange(new PizzaProcess[]
                    {
                        new PizzaProcess()
                        {
                            Id = 0,
                            Name = "Cooking",
                            Description = "",
                            Available = true,
                            PriceAddition = 10,
                            PriceModifier = 1
                        },
                        new PizzaProcess()
                        {
                            Id = 1,
                            Name = "Slicing",
                            Description = "",
                            Available = true,
                            PriceAddition = 3,
                            PriceModifier = 1
                        }
                    });
                }
                // Sauce
                if (!context.PizzaSauces.Any())
                {
                    context.PizzaSauces.AddRange(new PizzaSauce[]
                    {
                        new PizzaSauce()
                        {
                            Id = 0,
                            Name = "Ketchup",
                            Description = "",
                            Available = true,
                            PriceAddition = 20,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 1,
                            Name = "Mayonneise",
                            Description = "",
                            Available = true,
                            PriceAddition = 30,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 2,
                            Name = "Ketchunneise",
                            Description = "Mixed Ketchup and mayonneise!",
                            Available = true,
                            PriceAddition = 25,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 3,
                            Name = "Hunters",
                            Description = "",
                            Available = true,
                            PriceAddition = 25,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 4,
                            Name = "Creamy",
                            Description = "",
                            Available = true,
                            PriceAddition = 20,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 5,
                            Name = "Garlic",
                            Description = "",
                            Available = true,
                            PriceAddition = 40,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 6,
                            Name = "Creamy-Garlic",
                            Description = "",
                            Available = true,
                            PriceAddition = 30,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Id = 7,
                            Name = "Tomato pasta",
                            Description = "",
                            Available = true,
                            PriceAddition = 15,
                            PriceModifier = 1
                        }
                    });
                }
                // Sizes
                if (!context.PizzaSizes.Any())
                {
                    context.PizzaSizes.AddRange(new PizzaSize[]
                    {
                        new PizzaSize()
                        {
                            Id = 0,
                            Name = "Minimal",
                            Description = "18 cm",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 1.0d
                        },
                        new PizzaSize()
                        {
                            Id = 1,
                            Name = "Normal",
                            Description = "26",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 2.09d
                        },
                        new PizzaSize()
                        {
                            Id = 2,
                            Name = "Big",
                            Description = "36",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 4.0d
                        },
                        new PizzaSize()
                        {
                            Id = 3,
                            Name = "Huge",
                            Description = "60",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 11.11d
                        }
                    });
                }
                // Spices
                if (!context.PizzaSpices.Any())
                {
                    context.PizzaSpices.AddRange(new PizzaSpice[]
                    {
                        new PizzaSpice()
                        {
                            Id = 0,
                            Name = "Thyme",
                            Description = "",
                            Available = true,
                            PriceAddition = 1,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
                            Id = 1,
                            Name = "Rosemary",
                            Description = "",
                            Available = true,
                            PriceAddition = 1,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
                            Id = 2,
                            Name = "Coriander",
                            Description = "",
                            Available = true,
                            PriceAddition = 2,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
                            Id = 3,
                            Name = "Italian",
                            Description = "",
                            Available = true,
                            PriceAddition = 2,
                            PriceModifier = 1
                        }
                    });
                }
                // Toppings
                if (!context.PizzaToppings.Any())
                {
                    context.PizzaToppings.AddRange(new PizzaTopping[]
                    {
                        new PizzaTopping()
                        {
                            Id = 0,
                            Name = "Mushrooms",
                            Description = "",
                            Available = true,
                            PriceAddition = 190,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 1,
                            Name = "Beacon",
                            Description = "",
                            Available = true,
                            PriceAddition = 280,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 2,
                            Name = "Pepperoni",
                            Description = "",
                            Available = true,
                            PriceAddition = 270,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 3,
                            Name = "Sausages",
                            Description = "",
                            Available = true,
                            PriceAddition = 280,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 4,
                            Name = "Bell Pepper",
                            Description = "",
                            Available = true,
                            PriceAddition = 120,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 5,
                            Name = "Tomatoes",
                            Description = "",
                            Available = true,
                            PriceAddition = 210,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Id = 6,
                            Name = "Olives",
                            Description = "",
                            Available = true,
                            PriceAddition = 230,
                            PriceModifier = 1
                        },
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

                #region Actual seeding
                // Order Templates
                if (!context.OrderTemplates.Any())
                {
                    context.OrderTemplates.AddRange(new OrderTemplate[]
                    {
                        new OrderTemplate()
                        {
                            Name = "Pizza Pepperoni",
                            Description = "",
                            Order = new PizzaOrder()
                            {
                                Name = "",
                                Comment = "",
                                Size = new PizzaSize() 
                                {
                                    Id = 0
                                },
                                Dough = new PizzaDough()
                                {
                                    Id = 0
                                },
                                Cooking = 2,
                                Slicing = 3,
                                PrimeComplex = new PizzaComplexOrder()
                                {
                                    PizzaSauce = new PizzaSauceOrder[]
                                    {
                                        new PizzaSauceOrder()
                                        {
                                            Id = 7
                                        }
                                    },
                                    BaseOrder = new PizzaBaseOrder[]
                                    {
                                        new PizzaBaseOrder()
                                        {
                                            Id = 0
                                        },
                                        new PizzaBaseOrder()
                                        {
                                            Id = 2
                                        }
                                    },
                                    SpiceOrder = new PizzaSpiceOrder[]
                                    {
                                        new PizzaSpiceOrder()
                                        {
                                            Id = 3
                                        }
                                    },
                                    ToppingOrder = new PizzaToppingOrder[]
                                    {
                                        new PizzaToppingOrder()
                                        {
                                            Id = 2
                                        }
                                    }
                                },
                                SecondComplex = null
                            }
                        }
                    });
                }
                #endregion

                context.SaveChanges();
            }
        }
    }
}
