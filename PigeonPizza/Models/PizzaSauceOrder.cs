namespace PigeonPizza.Models
{
    public class PizzaSauceOrder
    {
        public int Id { get; set; }
        public PizzaSauce Order { get; set; }
        public double Amount { get; set; }
    }
}
