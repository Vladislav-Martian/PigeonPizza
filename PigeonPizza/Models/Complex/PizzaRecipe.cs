using PigeonPizza.Models.Basics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Complex
{
    public class PizzaRecipe
    {
        [Key]
        public int Id { get; set; }

        #region Recipe
        [Required]
        public PizzaScale Scale { get; set; }
        [Required]
        public PizzaDough Dough { get; set; }
        public PublishRecipe Publish { get; set; }
        public ICollection<BasicsTask> Tasks { get; set; }
        
        #endregion


        #region Builder
        public class Builder
        {
            public PizzaRecipe Recipe { get; set; }

            public Builder()
            {
                Recipe = new PizzaRecipe();
            }

            public PizzaRecipe Built => Recipe;

            public PizzaRecipe Build() => Recipe;

            #region Construct
            public Builder SetScale(PizzaScale element)
            {
                Recipe.Scale = element;
                return this;
            }

            public Builder SetDough(PizzaDough element)
            {
                Recipe.Dough = element;
                return this;
            }

            public Builder Publish(string name, string description = null)
            {
                Recipe.Publish = new PublishRecipe(name, description);
                return this;
            }

            public Builder AddBasic(PizzaBasic element, int amount)
            {
                if (element == null)
                {
                    return this;
                }

                if (Recipe.Tasks == null)
                {
                    Recipe.Tasks = new List<BasicsTask>();
                }

                Recipe.Tasks.Add(new BasicsTask(element, amount));

                return this;
            }
            #endregion
        }
        #endregion
    }
}
