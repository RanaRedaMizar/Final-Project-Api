using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class AnalysisType
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; } 
        public virtual List<AppointmentAnalysis> AppointmentAnalysiss { get; set; } 





    }
}
