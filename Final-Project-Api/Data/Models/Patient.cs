using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Api.Data.Models
{
    public class Patient : ApplicationUser
    {
        [Key, Required]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public int TotalBookings => Bookings?.Count ?? 0;

    }
}
