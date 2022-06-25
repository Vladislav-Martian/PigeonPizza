using System;

namespace PigeonPizza.Models.Controls
{
    public class RejectedOrder
    {
        public int Id { get; set; }
        public DateTime Timetag { get; set; }
        public string Reason { get; set; }
    }
}
