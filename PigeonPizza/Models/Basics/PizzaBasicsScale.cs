using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PizzaBasicsScale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public decimal Diameter { get; set; }

        public decimal CalculatePriceModifier(decimal BaseDiameter)
        {
            return (decimal) Math.Pow((double)Diameter / (double)BaseDiameter, 2);
        }

        #region Constructor
        public PizzaBasicsScale()
        {
            Name = null;
            Diameter = 0;
            Description = null;
            InStock = false;
        }

        public PizzaBasicsScale(string name, decimal diameter, string description = null)
        {
            Name = name;
            Diameter = diameter;
            Description = description;
            InStock = false;
        }
        #endregion

        #region Navigation

        #endregion
    }
}
