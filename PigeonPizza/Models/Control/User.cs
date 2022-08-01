using System;
using System.ComponentModel.DataAnnotations;

namespace PigeonPizza.Models.Control
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public Guid UUID { get; set; }
        public bool IsGuest { get; set; }
    }
}
