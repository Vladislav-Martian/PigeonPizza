namespace PigeonPizza.Models
{
    public class PizzaToppingOrder
    {
        public int Id { get; set; }
        public PizzaTopping Order { get; set; }
        public double Amount { get; set; }
    }
}
