using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PizzaBasicsDough
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public decimal Price { get; set; }

        #region Constructor
        public PizzaBasicsDough()
        {
            Name = null;
            Price = 0;
            Description = null;
            InStock = false;
        }

        public PizzaBasicsDough(string name, decimal price, string description = null)
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
