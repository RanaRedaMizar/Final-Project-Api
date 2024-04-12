using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Infrastructure.Services
{
    public class DiseaseService  : IDiseaseService
    {
        private readonly IDiseaseRepository _repository;

        public DiseaseService(IDiseaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Disease> AddNewDisease(Disease disease)
        {
            try
            {
                return await _repository.AddNewDisease(disease);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding disease: {ex}");
                throw;
            }
        }

        public bool DeleteDisease(int disease)
        {
            return  _repository.DeleteDisease(disease);
        }

        public async Task<IActionResult> GetAll()
        {
            var Diseases = await _repository.GetAll();
            var DiseaseDTOs = Diseases.Select(s => new DiseaseDTO
            {
                Name = s.Name,
                Description = s.Description,
                Type = s.Type,
            }).ToList();

            return new OkObjectResult(DiseaseDTOs);
        }

    }
}
