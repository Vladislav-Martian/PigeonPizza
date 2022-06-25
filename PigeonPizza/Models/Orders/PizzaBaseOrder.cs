using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Models.Orders
{
    public class PizzaBaseOrder
    {
        public int Id { get; set; }
        public PizzaBase Order { get; set; }
        public double Amount { get; set; }
    }
}
