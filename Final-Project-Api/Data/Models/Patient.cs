namespace Final_Project_Api.Data.Models
{
    public class Patient : ApplicationUser
    {
        public int Age { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
