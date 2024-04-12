using Final_Project_Api.Data;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _context;

        public MedicineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetAll()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task<Medicine> AddNewMedicine(Medicine medicine)
        {


            var newMedicine = new Medicine
            {
                
                GenericName = medicine.GenericName,
                BrandName = medicine.BrandName,
                Type = medicine.Type,

            };

            _context.Medicines.Add(newMedicine);
            _context.SaveChanges();

            return newMedicine;
        }

        public bool DeleteMedicine(int id)
        {
            var medicineToDelete = _context.Medicines.Find(id);

            if (medicineToDelete != null)
            {
                _context.Medicines.Remove(medicineToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

       
    }
}
