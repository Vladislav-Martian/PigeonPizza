using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Models.Orders
{
    public class PizzaSpiceOrder
    {
        public int Id { get; set; }
        public PizzaSpice Order { get; set; }
        public double Amount { get; set; }
    }
}
