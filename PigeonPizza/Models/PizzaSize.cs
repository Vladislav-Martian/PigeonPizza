namespace PigeonPizza.Models
{
    public class PizzaSize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region Useful props
        public double PriceModifier { get; set; } = 1;
        public double PriceAddition { get; set; } = 0;
        #endregion
    }
}
