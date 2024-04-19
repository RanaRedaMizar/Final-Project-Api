using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.Models
{
    public class Specialization
    {
        [Key, Required]
        public int SpecializationId { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();

    }
}
