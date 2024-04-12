using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Final_Project_Api.Data.DToModels
{
    public partial class PateintDTO : LoginDto
    {
        [Key,Required]
        public string Id { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime BirthDate { get; set; }
        [Required, RegularExpression(@"^01[0125]\d{8}$")]
        public string Phone { get; set; }
        public GendersEnum Gender { get; set; }
     //   public IFormFile ImageFile { get; set; }
        public string? Image { get; set; }
    }
}
