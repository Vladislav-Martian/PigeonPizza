﻿namespace PigeonPizza.Models
{
    public class PizzaComplexOrder
    {
        public int Id { get; set; }
        #region Addition
        public PizzaSauceOrder[] PizzaSauce { get; set; }
        public PizzaBaseOrder[] BaseOrder { get; set; }
        public PizzaToppingOrder[] ToppingOrder { get; set; }
        public PizzaSpiceOrder[] SpiceOrder { get; set; }
        #endregion

        #region Other
        public string Comment { get; set; } = null;
        #endregion
    }
}
