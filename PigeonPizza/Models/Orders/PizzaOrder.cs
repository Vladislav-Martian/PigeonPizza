using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Models.Orders
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public PizzaSize Size { get; set; }
        public PizzaDough Dough { get; set; }
        public PizzaProcess Process { get; set; }
        public PizzaComplexOrder PrimeComplex { get; set; }
        public PizzaComplexOrder SecondComplex { get; set; }
    }
}
