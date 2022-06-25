namespace PigeonPizza.Models.Orders
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
    }
}
