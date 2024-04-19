using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class AnalysisType
    {
        [Key,Required]
        public int AnalysisTypeId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } 
        public virtual List<AppointmentAnalysis> AppointmentAnalysiss { get; set; } 





    }
}
