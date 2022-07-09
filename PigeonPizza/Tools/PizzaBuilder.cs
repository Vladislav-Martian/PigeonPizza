using PigeonPizza.Contexts;
using PigeonPizza.Models.Orders;
using PigeonPizza.Models.Primitive;
using System.Collections.Generic;

namespace PigeonPizza.Tools
{
    public class PizzaBuilder
    {
        #region model
        public string Name { get; set; } = null;
        public string Comment { get; set; } = null;
        public PizzaSize Size { get; set; }
        public PizzaDough Dough { get; set; }
        public ICollection<PizzaProcessOrder> Processing { get; set; }
        public PizzaComplexOrder PrimeComplex { get; set; }
        public PizzaComplexOrder SecondComplex { get; set; }

        private PizzaComplexOrder ComplexToBuild;

        public PizzaOrder Build()
        {
            return new PizzaOrder()
            {
                Name = Name,
                Comment = Comment,
                Size = Size,
                Processing = Processing,
                PrimeComplex = PrimeComplex,
                SecondComplex = SecondComplex,
            };
        }

        public PizzaBuilder()
        {
            SwitchToPrimeComplex();
        }

        #endregion

        #region Name, Comment, Size, Dough, Process
        public PizzaBuilder SetName(string element)
        {
            Name = element;
            return this;
        }
        public PizzaBuilder SetComment(string element)
        {
            Comment = element;
            return this;
        }
        public PizzaBuilder SetSize(PizzaSize element)
        {
            Size = element;
            return this;
        }
        public PizzaBuilder SetDough(PizzaDough element)
        {
            Dough = element;
            return this;
        }
        public PizzaBuilder AddProcess(PizzaProcess process, double amount = 1.0)
        {
            if (Processing == null)
            {
                Processing = new List<PizzaProcessOrder>();
            }

            Processing.Add(new PizzaProcessOrder()
            {
                Order = process,
                Amount = amount
            });

            return this;
        }
        #endregion

        #region Switching complex to build
        /* How to use:
        Switch complex, u want to edit, y default working on prime complex, secondary is null
        After - just use methods to add new ingridients to the complex.

        Example:
        builder
            .SetName...
            .SetComment...
            .SetDough...
            .Addprocess...
            .Addprocess...
            // On prime complex
            .AddSauce...
            .AddBase...
            .AddTopping...
            .AddSpice...
            .SwitchToSecondComplex()
            // Now on secondary
            .AddSauce...
            .AddBase...
            .AddTopping...
            .AddSpice...
            .Build() // Finished
        */
        public PizzaBuilder SwitchToPrimeComplex()
        {
            if (PrimeComplex == null)
            {
                PrimeComplex = new PizzaComplexOrder();
            }
            ComplexToBuild = PrimeComplex;
            return this;
        }
        public PizzaBuilder SwitchToSecondComplex()
        {
            if (SecondComplex == null)
            {
                SecondComplex = new PizzaComplexOrder();
            }
            ComplexToBuild = SecondComplex;
            return this;
        }
        #endregion

        #region Building complex (Sauce, Base, Topping, Spice)
        public PizzaBuilder AddSauce(PizzaSauce element, double amount)
        {
            if (ComplexToBuild.PizzaSauce == null)
            {
                ComplexToBuild.PizzaSauce = new List<PizzaSauceOrder>();
            }
            ComplexToBuild.PizzaSauce.Add(new PizzaSauceOrder()
            {
                Order = element,
                Amount = amount
            });
            return this;
        }
        public PizzaBuilder AddBase(PizzaBase element, double amount)
        {
            if (ComplexToBuild.BaseOrder == null)
            {
                ComplexToBuild.BaseOrder = new List<PizzaBaseOrder>();
            }
            ComplexToBuild.BaseOrder.Add(new PizzaBaseOrder()
            {
                Order = element,
                Amount = amount
            });
            return this;
        }
        public PizzaBuilder AddTopping(PizzaTopping element, double amount)
        {
            if (ComplexToBuild.ToppingOrder == null)
            {
                ComplexToBuild.ToppingOrder = new List<PizzaToppingOrder>();
            }
            ComplexToBuild.ToppingOrder.Add(new PizzaToppingOrder()
            {
                Order = element,
                Amount = amount
            });
            return this;
        }
        public PizzaBuilder AddSpice(PizzaSpice element, double amount)
        {
            if (ComplexToBuild.SpiceOrder == null)
            {
                ComplexToBuild.SpiceOrder = new List<PizzaSpiceOrder>();
            }
            ComplexToBuild.SpiceOrder.Add(new PizzaSpiceOrder()
            {
                Order = element,
                Amount = amount
            });
            return this;
        }
        #endregion
    }
}
