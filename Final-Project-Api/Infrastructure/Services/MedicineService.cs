using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Infrastructure.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<Medicine> AddNewMedicine(Medicine medicine)
        {
            try
            {
                return await _repository.AddNewMedicine(medicine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding medicine: {ex}");
                throw;
            }
        }

        public bool DeleteMedicine(int medicine)
        {
            return  _repository.DeleteMedicine(medicine);
        }

        public async Task<IActionResult> GetAll()
        {
            var Medicines = await _repository.GetAll();
            var MedicineDTOs = Medicines.Select(s => new MedicineDTO
            {
                GenericName = s.GenericName,
                BrandName = s.BrandName,
                Type = s.Type,
            }).ToList();

            return new OkObjectResult(MedicineDTOs);
        }

    }
}
