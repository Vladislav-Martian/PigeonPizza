using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PizzaBasicsTopping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public decimal Price { get; set; }

        #region Constructor
        public PizzaBasicsTopping()
        {
            Name = null;
            Price = 0;
            Description = null;
            InStock = false;
        }

        public PizzaBasicsTopping(string name, decimal price, string description = null)
        {
            Name = name;
            Price = price;
            Description = description;
            InStock = false;
        }
        #endregion

        #region Navigation

        #endregion
    }
}
