using PigeonPizza.Models.Orders;

namespace PigeonPizza.Models.Other
{
    public class PizzaComplexTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        #region Addition
        public PizzaSauceOrder[] PizzaSauce { get; set; }
        public PizzaBaseOrder[] BaseOrder { get; set; }
        public PizzaToppingOrder[] ToppingOrder { get; set; }
        public PizzaSpiceOrder[] SpiceOrder { get; set; }
        #endregion
    }
}
