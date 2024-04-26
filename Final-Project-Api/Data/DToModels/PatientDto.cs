﻿using Final_Project_Api.Data.Enums;
using System.ComponentModel.DataAnnotations;


namespace Final_Project_Api.Data.DToModels
{
    public  class PatientDetailsDto : LoginDto
    {
        public string Id { get;set; }

        [Required, MinLength(3), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required, RegularExpression(@"^01[0125]\d{8}$")]
        public string Phone { get; set; }
        public int Age { get; set; }
        public GendersEnum Gender { get; set; }
     //   public IFormFile ImageFile { get; set; }
        public string? Image { get; set; }
    }

    public class PatientDto : LoginDto
    {

        [Required, MinLength(3), MaxLength(64)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [Required, RegularExpression(@"^01[0125]\d{8}$")]
        public string Phone { get; set; }
        public int Age { get; set; }
        public GendersEnum Gender { get; set; }
        //   public IFormFile ImageFile { get; set; }
        public string? Image { get; set; }
    }
}
