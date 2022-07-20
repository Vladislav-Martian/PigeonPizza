using Microsoft.EntityFrameworkCore;
using PigeonPizza.Models.Complex;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PizzaBasic
    {
        [Key]
        public int Id { get; set; }

        public PizzaBasicType Type { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public decimal Price { get; set; }

        #region Constructor
        public PizzaBasic()
        {
            Type = PizzaBasicType.Topping;
            Name = null;
            Price = 0;
            Description = null;
            InStock = false;
        }

        public PizzaBasic(PizzaBasicType type, string name, decimal price, string description = null)
        {
            Type = type;
            Name = name;
            Price = price;
            Description = description;
            InStock = false;
        }
        #endregion

        #region Navigation
        public ICollection<BasicsTask> Tasks { get; set; }
        #endregion
    }
}
