using PigeonPizza.Models.Orders;
using System;

namespace PigeonPizza.Models.Controls
{
    public class QueuedOrder
    {
        public int Id { get; set; }
        public int ClientIdentifier { get; set; }
        public DateTime Timetag { get; set; }
        public PizzaOrder Order { get; set; }
        public UserDiscount[] Discounts { get; set; }
    }
}
