using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.DToModels
{
    public class AnalysisTypeDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
