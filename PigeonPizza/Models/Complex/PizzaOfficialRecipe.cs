﻿using PigeonPizza.Models.Basics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PigeonPizza.Extension;

namespace PigeonPizza.Models.Complex
{
    public class PizzaOfficialRecipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        #region Recipe elements
        public PizzaBasicsDough Dough { get; set; }
        public ICollection<PizzaBasicsCover> Covers { get; set; }
        public ICollection<PizzaBasicsTopping> Toppings { get; set; }
        public ICollection<PizzaBasicsWork> Works { get; set; }
        public PizzaBasicsScale Scale { get; set; }
        #endregion

        #region Constructors
        public PizzaOfficialRecipe()
        {
            Name = null;
            Description = null;
            Dough = null;
            Covers = new List<PizzaBasicsCover>();
            Toppings = new List<PizzaBasicsTopping>();
            Works = new List<PizzaBasicsWork>();
            Scale = null;
        }
        public PizzaOfficialRecipe(string name, string description = null)
        {
            Name = name;
            Description = description;
            Dough = null;
            Covers = new List<PizzaBasicsCover>();
            Toppings = new List<PizzaBasicsTopping>();
            Works = new List<PizzaBasicsWork>();
            Scale = null;
        }
        #endregion

        #region Builder as internal class
        public sealed class Builder
        {
            public PizzaOfficialRecipe Recipe { get; private set; }

            public Builder()
            {
                Recipe = new PizzaOfficialRecipe();
            }

            public bool IsComplete()
            {
                if (string.IsNullOrEmpty(Recipe.Name)) return false;
                if (Recipe.Dough == null) return false;
                if (Recipe.Scale == null) return false;
                if (Recipe.Works.Count <= 0) return false;
                if (Recipe.Covers.Count <= 0 || Recipe.Toppings.Count <= 0) return false;
                return true;
            }

            public PizzaOfficialRecipe Build()
            {
                if (!IsComplete())
                {
                    throw new System.Exception("Builder is not ready to setup full Recipe.");
                }
                return Recipe;
            }

            public PizzaOfficialRecipe Built => Build();

            public Builder NameAndDescription(string name, string description = null)
            {
                Recipe.Name = name;
                Recipe.Description = description;
                return this;
            }

            public Builder SetDough(PizzaBasicsDough dough)
            {
                Recipe.Dough = dough;
                return this;
            }

            public Builder SetScale(PizzaBasicsScale scale)
            {
                Recipe.Scale = scale;
                return this;
            }

            public Builder AddCover(PizzaBasicsCover item, int amount)
            {
                amount.Times(() =>
                {
                    Recipe.Covers.Add(item);
                });
                return this;
            }

            public Builder AddTopping(PizzaBasicsTopping item, int amount)
            {
                amount.Times(() =>
                {
                    Recipe.Toppings.Add(item);
                });
                return this;
            }

            public Builder AddWork(PizzaBasicsWork item, int amount)
            {
                amount.Times(() =>
                {
                    Recipe.Works.Add(item);
                });
                return this;
            }
        }
        #endregion
    }
}
