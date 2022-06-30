using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Models.Orders
{
    public class PizzaProcessOrder
    {
        public int Id { get; set; }
        public PizzaProcess Order { get; set; }
        public double Amount { get; set; }
    }
}
