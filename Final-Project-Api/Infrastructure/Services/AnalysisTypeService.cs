using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Infrastructure.Services
{
    public class AnalysisTypeService : IAnalysisTypeService
    {
        private readonly IAnalysisTypeRepository _repository;

        public AnalysisTypeService(IAnalysisTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<AnalysisType> AddNewAnalysisType(AnalysisType analysisType)
        {
            try
            {
                return await _repository.AddNewAnalysisType(analysisType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding analysisType: {ex}");
                throw;
            }
        }

        public bool DeleteAnalysisType(int analysisType)
        {
            return _repository.DeleteAnalysisType(analysisType);
        }

        public async Task<IActionResult> GetAll()
        {
            var AnalysisTypes = await _repository.GetAll();
            var AnalysisTypeDTOs = AnalysisTypes.Select(s => new AnalysisTypeDTO
            {
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return new OkObjectResult(AnalysisTypeDTOs);
        }
    }
}
