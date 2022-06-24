namespace PigeonPizza.Models
{
    public class PizzaSpiceOrder
    {
        public int Id { get; set; }
        public PizzaSpice Order { get; set; }
        public double Amount { get; set; }
    }
}
