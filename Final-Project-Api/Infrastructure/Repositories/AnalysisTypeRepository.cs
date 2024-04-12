using Final_Project_Api.Data.Models;
using Final_Project_Api.Data;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class AnalysisTypeRepository : IAnalysisTypeRepository
    {

        private readonly AppDbContext _context;
        public AnalysisTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnalysisType>> GetAll()
        {
            return await _context.AnalysisTypes.ToListAsync();
        }

        public async Task<AnalysisType> AddNewAnalysisType(AnalysisType analysisType)
        {


            var newAnalysisType = new AnalysisType
            {

                Name = analysisType.Name,
                Description = analysisType.Description,
                

            };

            _context.AnalysisTypes.Add(newAnalysisType);
            _context.SaveChanges();
            return newAnalysisType;
        }

        public  bool DeleteAnalysisType(int id)
        {
            var analysisTypeToDelete = _context.AnalysisTypes.Find(id);

            if (analysisTypeToDelete != null)
            {
                _context.AnalysisTypes.Remove(analysisTypeToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
