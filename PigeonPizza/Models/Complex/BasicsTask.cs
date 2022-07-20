using PigeonPizza.Models.Basics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Complex
{
    public class BasicsTask
    {
        [Key]
        public int Id { get; set; }

        public PizzaBasic Element { get; set; }

        public int Amount { get; set; }

        public BasicsTask()
        {
            Element = null;
            Amount = 0;
        }

        public BasicsTask(PizzaBasic element, int amount)
        {
            Element = element;
            Amount = amount;
        }

        #region Navigation
        public ICollection<PizzaRecipe> Recipes { get; set; }
        #endregion
    }
}
