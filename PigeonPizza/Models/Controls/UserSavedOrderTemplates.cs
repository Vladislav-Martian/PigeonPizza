namespace PigeonPizza.Models.Controls
{
    public class UserSavedOrderTemplates
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public OrderTemplate Order { get; set; }
    }
}
