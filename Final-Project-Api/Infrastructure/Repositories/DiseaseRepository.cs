using Final_Project_Api.Data.Models;
using Final_Project_Api.Data;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly AppDbContext _context;

        public DiseaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disease>> GetAll()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> AddNewDisease(Disease disease)
        {


            var newDisease = new Disease
            {

                Name = disease.Name,
                Description = disease.Description,
                Type = disease.Type,

            };

            _context.Diseases.Add(newDisease);
            _context.SaveChanges();

            return newDisease;
        }

        public bool DeleteDisease(int id)
        {
            var diseaseToDelete = _context.Diseases.Find(id);

            if (diseaseToDelete != null)
            {
                _context.Diseases.Remove(diseaseToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

