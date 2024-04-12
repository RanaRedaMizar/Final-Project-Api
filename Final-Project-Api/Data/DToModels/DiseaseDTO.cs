using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.DToModels
{
    public class DiseaseDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;

    }
}
