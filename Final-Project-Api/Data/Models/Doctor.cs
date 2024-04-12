using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Api.Data.Models
{
    public class Doctor : ApplicationUser
    {
        [Key, Required]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public int SpecializeId { get; set; }
        public virtual Specialization Specialize { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
