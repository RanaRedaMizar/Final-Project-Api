using System.ComponentModel.DataAnnotations;

namespace Final_Project_Api.Data.DToModels
{
    public partial class MedicineDTO
    {
 
        [Required]
        public string GenericName { get; set; } = null!;
        [Required]
        public string BrandName { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;

    }

}
