﻿namespace PigeonPizza.Models.Primitive
{
    public class PizzaSize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }

        #region Useful props
        public double PriceModifier { get; set; } = 1;
        public double PriceAddition { get; set; } = 0;
        #endregion
    }
}