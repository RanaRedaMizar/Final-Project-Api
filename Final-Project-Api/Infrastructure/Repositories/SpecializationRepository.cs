using Final_Project_Api.Data;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly AppDbContext _context;

        public SpecializationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Specialization>> GetAll()
        {
            return await _context.Specializations.ToListAsync();
        }

        public async Task<Specialization> AddNewSpecialization(Specialization specialization)
        {


            var newSpecialization = new Specialization
            {
                //Id = specialization.Id,
                Title = specialization.Title,
                
            };

            _context.Specializations.Add(newSpecialization);
            _context.SaveChanges();

            return newSpecialization;
        }

        public bool DeleteSpecilization(int id)
        {
            var specializationToDelete = _context.Specializations.Find(id);

            if (specializationToDelete != null)
            {
                _context.Specializations.Remove(specializationToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Specialization>> TopSpecilization()
        {

            var topspe = await _context.Specializations
                .OrderByDescending(s => s.Doctors.Count())
                .Take(5)
                .ToListAsync();
            return topspe;

        }
    }

}

