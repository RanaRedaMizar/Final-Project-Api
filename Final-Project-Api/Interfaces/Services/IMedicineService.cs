using Final_Project_Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IMedicineService
    {
        Task<IActionResult> GetAll();
        Task<Medicine> AddNewMedicine(Medicine medicine);
       bool DeleteMedicine(int medicineId);
    }
}
