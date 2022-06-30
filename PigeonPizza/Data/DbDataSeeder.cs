using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Primitive;
using PigeonPizza.Models.Orders;
using PigeonPizza.Models.Controls;
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
                // Bases
                if (!context.PizzaBases.Any())
                {
                    context.PizzaBases.AddRange(new PizzaBase[]
                    {
                        new PizzaBase()
                        {
                            Name = "Mozzarella",
                            Description = "",
                            Available = true,
                            PriceAddition = 250,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
                            Name = "Parmesan",
                            Description = "",
                            Available = true,
                            PriceAddition = 230,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
                            Name = "Cheddar",
                            Description = "",
                            Available = true,
                            PriceAddition = 290,
                            PriceModifier = 1
                        },
                        new PizzaBase()
                        {
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
                            Name = "Wheat",
                            Description = "",
                            Available = true,
                            PriceAddition = 50,
                            PriceModifier = 1
                        },
                        new PizzaDough()
                        {
                            Name = "Puff paste",
                            Description = "",
                            Available = true,
                            PriceAddition = 60,
                            PriceModifier = 1
                        },
                        new PizzaDough()
                        {
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
                            Name = "Cooking",
                            Description = "",
                            Available = true,
                            PriceAddition = 10,
                            PriceModifier = 1
                        },
                        new PizzaProcess()
                        {
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
                            Name = "Ketchup",
                            Description = "",
                            Available = true,
                            PriceAddition = 20,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Mayonneise",
                            Description = "",
                            Available = true,
                            PriceAddition = 30,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Ketchunneise",
                            Description = "Mixed Ketchup and mayonneise!",
                            Available = true,
                            PriceAddition = 25,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Hunters",
                            Description = "",
                            Available = true,
                            PriceAddition = 25,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Creamy",
                            Description = "",
                            Available = true,
                            PriceAddition = 20,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Garlic",
                            Description = "",
                            Available = true,
                            PriceAddition = 40,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
                            Name = "Creamy-Garlic",
                            Description = "",
                            Available = true,
                            PriceAddition = 30,
                            PriceModifier = 1
                        },
                        new PizzaSauce()
                        {
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
                            Name = "Minimal",
                            Description = "18 cm",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 1.0d
                        },
                        new PizzaSize()
                        {
                            Name = "Normal",
                            Description = "26",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 2.09d
                        },
                        new PizzaSize()
                        {
                            Name = "Big",
                            Description = "36",
                            Available = true,
                            PriceAddition = 0,
                            PriceModifier = 4.0d
                        },
                        new PizzaSize()
                        {
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
                            Name = "Thyme",
                            Description = "",
                            Available = true,
                            PriceAddition = 1,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
                            Name = "Rosemary",
                            Description = "",
                            Available = true,
                            PriceAddition = 1,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
                            Name = "Coriander",
                            Description = "",
                            Available = true,
                            PriceAddition = 2,
                            PriceModifier = 1
                        },
                        new PizzaSpice()
                        {
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
                            Name = "Mushrooms",
                            Description = "",
                            Available = true,
                            PriceAddition = 190,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Name = "Beacon",
                            Description = "",
                            Available = true,
                            PriceAddition = 280,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Name = "Pepperoni",
                            Description = "",
                            Available = true,
                            PriceAddition = 270,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Name = "Sausages",
                            Description = "",
                            Available = true,
                            PriceAddition = 280,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Name = "Bell Pepper",
                            Description = "",
                            Available = true,
                            PriceAddition = 120,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
                            Name = "Tomatoes",
                            Description = "",
                            Available = true,
                            PriceAddition = 210,
                            PriceModifier = 1
                        },
                        new PizzaTopping()
                        {
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
                // Ingridients orders making
                PizzaComplexOrder PepperoniOrder = new PizzaComplexOrder()
                {
                    PizzaSauce = new List<PizzaSauceOrder>(),
                    BaseOrder = new List<PizzaBaseOrder>(),
                    SpiceOrder = null,
                    ToppingOrder = new List<PizzaToppingOrder>(),
                };

                if (!context.PizzaBaseOrders.Any())
                {

                    var order1 = new PizzaBaseOrder()
                    {
                        Order = context.PizzaBases.FirstOrDefault(x => x.Id == 0),
                        Amount = 1.0
                    };
                    context.PizzaBaseOrders.Add(order1);
                    var order2 = new PizzaBaseOrder()
                    {
                        Order = context.PizzaBases.FirstOrDefault(x => x.Id == 2),
                        Amount = 1.0
                    };
                    context.PizzaBaseOrders.Add(order2);

                    context.SaveChanges();

                    PepperoniOrder.BaseOrder.Add(order1);
                    PepperoniOrder.BaseOrder.Add(order2);
                }

                if (!context.PizzaSauceOrders.Any())
                {
                    var order1 = new PizzaSauceOrder()
                    {
                        Order = context.PizzaSauces.FirstOrDefault(x => x.Id == 7),
                        Amount = 1.0
                    };
                    context.PizzaSauceOrders.Add(order1);

                    context.SaveChanges();

                    PepperoniOrder.PizzaSauce.Add(order1);
                }

                if (!context.PizzaToppingOrders.Any())
                {
                    var order1 = new PizzaToppingOrder()
                    {
                        Order = context.PizzaToppings.FirstOrDefault(x => x.Id == 2),
                        Amount = 1.0
                    };
                    context.PizzaToppingOrders.Add(order1);

                    context.SaveChanges();

                    PepperoniOrder.ToppingOrder.Add(order1);
                }
                // Complex order
                if (!context.PizzaComplexOrders.Any())
                {
                    context.PizzaComplexOrders.Add(PepperoniOrder);
                    context.SaveChanges();
                }

                // ProcessOrder
                var processing = new List<PizzaProcessOrder>
                {
                    new PizzaProcessOrder
                    {
                        Order = context.PizzaProcesses.FirstOrDefault(x => x.Id == 0),
                        Amount = 1
                    },
                    new PizzaProcessOrder
                    {
                        Order = context.PizzaProcesses.FirstOrDefault(x => x.Id == 2),
                        Amount = 3
                    }
                };
                if (!context.PizzaProcessOrders.Any())
                {
                    context.PizzaProcessOrders.Add(processing[0]);
                    context.PizzaProcessOrders.Add(processing[1]);
                    context.SaveChanges();
                }

                // Pizza order
                var order = new PizzaOrder()
                {
                    Name = "Pepperoni pizza",
                    Comment = "Tomato-sauce, 2-cheese-base, pepperoni topping.",
                    Size = context.PizzaSizes.FirstOrDefault(x => x.Id == 2),
                    Dough = context.PizzaDoughs.FirstOrDefault(x => x.Id == 0),
                    PrimeComplex = PepperoniOrder,
                    SecondComplex = null,
                    Processing = processing
                };

                // Order Templates
                if (!context.OrderTemplates.Any())
                {
                    context.OrderTemplates.Add(new OrderTemplate
                    {
                        Order = order,
                        Name = "Pepperoni Pizza order",
                        Description = ""
                    });
                }
                #endregion

                context.SaveChanges();
            }
        }
    }
}
