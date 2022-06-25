using PigeonPizza.Models.Orders;

namespace PigeonPizza.Models.Controls
{
    public class OrderTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PizzaOrder Order { get; set; }
    }
}
