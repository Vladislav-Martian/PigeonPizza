using System.Collections.Generic;

namespace PigeonPizza.Models.Orders
{
    public class PizzaComplexOrder
    {
        public int Id { get; set; }
        #region Addition
        public ICollection<PizzaSauceOrder> SauceOrder { get; set; }
        public ICollection<PizzaBaseOrder> BaseOrder { get; set; }
        public ICollection<PizzaToppingOrder> ToppingOrder { get; set; }
        public ICollection<PizzaSpiceOrder> SpiceOrder { get; set; }
        #endregion
    }
}
