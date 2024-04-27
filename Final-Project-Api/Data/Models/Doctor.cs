namespace Final_Project_Api.Data.Models
{
    public class Doctor : ApplicationUser
    {
        public int SpecializeId { get; set; }
        public virtual Specialization Specialize { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
