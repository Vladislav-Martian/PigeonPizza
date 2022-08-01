using PigeonPizza.Models.Basics;
using PigeonPizza.Models.Complex;
using System;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Control
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Client { get; set; }

        [Required]
        public PizzaRecipe Recipe { get; set; }

        [Required]
        public PizzaScale Scale { get; set; }

        public DateTime Time { get; set; }

        public Order()
        {
            Client = null;
            Recipe = null;
            Scale = null;
            Time = DateTime.Now;
        }
    }
}
