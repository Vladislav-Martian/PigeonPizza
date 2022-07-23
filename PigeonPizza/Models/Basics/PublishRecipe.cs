using PigeonPizza.Models.Complex;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Basics
{
    public class PublishRecipe
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public PublishRecipe(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
