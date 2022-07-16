using Microsoft.EntityFrameworkCore;
using PigeonPizza.Models.Complex;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PizzaBasicsCover
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public decimal Price { get; set; }

        #region Constructor
        public PizzaBasicsCover()
        {
            Name = null;
            Price = 0;
            Description = null;
            InStock = false;
        }

        public PizzaBasicsCover(string name, decimal price, string description = null)
        {
            Name = name;
            Price = price;
            Description = description;
            InStock = false;
        }
        #endregion

        #region Navigation
        public ICollection<PizzaCustomRecipe> CustomRecipes { get; set; } = new List<PizzaCustomRecipe>();
        public ICollection<PizzaOfficialRecipe> OfficialRecipes { get; set; } = new List<PizzaOfficialRecipe>();
        #endregion
    }
}
