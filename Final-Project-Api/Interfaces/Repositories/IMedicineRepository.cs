using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAll();
        Task<Medicine> AddNewMedicine(Medicine medicine);
       bool DeleteMedicine(int medicineId);
    }
}
