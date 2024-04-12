using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Validations;

namespace Final_Project_Api.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? Image { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required, RegularExpression(@"^01[0125]\d{8}$")]
        public string Phone { get; set; }
        public GendersEnum Gender { get; set; }
    }
}


