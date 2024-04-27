using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;


namespace Final_Project_Api.Data.DToModels
{
    public class DoctorDetailsDTO
    {
        [Key, Required]
        public string Id { get; set; }

        public string Email { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required, RegularExpression(@"^01[0125]\d{8}$")]
        public string Phone { get; set; }
        public GendersEnum Gender { get; set; }
        public int SpecializeId { get; set; }
        public string? Image { get; set; }
    }
}
