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
                        Order = context.PizzaBases.First(x => x.Id == 0),
                        Amount = 1.0
                    };
                    context.PizzaBaseOrders.Add(order1);
                    var order2 = new PizzaBaseOrder()
                    {
                        Order = context.PizzaBases.First(x => x.Id == 2),
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
                        Order = context.PizzaSauces.First(x => x.Id == 7),
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
                        Order = context.PizzaToppings.First(x => x.Id == 2),
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
                        Order = context.PizzaProcesses.First(x => x.Id == 0),
                        Amount = 1
                    },
                    new PizzaProcessOrder
                    {
                        Order = context.PizzaProcesses.First(x => x.Id == 2),
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
                    Size = context.PizzaSizes.First(x => x.Id == 2),
                    Dough = context.PizzaDoughs.First(x => x.Id == 0),
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
