using System;

namespace PigeonPizza.Models.Controls
{
    public class ApprovedOrder
    {
        public int Id { get; set; }
        public DateTime Timetag { get; set; }
        public string Message { get; set; }
        public decimal Price { get; set; }
    }
}
