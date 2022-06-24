namespace PigeonPizza.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public PizzaDough Dough { get; set; }
        public int Cooking { get; set; } = 2;
        public int Slicing { get; set; } = 3;
        public PizzaComplexOrder PrimeComplex { get; set; }
        public PizzaComplexOrder SecondComplex { get; set; }
    }
}
