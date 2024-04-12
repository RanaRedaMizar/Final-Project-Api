using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Infrastructure.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _repository;

        public SpecializationService(ISpecializationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Specialization> AddNewSpecialization(Specialization specialization)
        {
            try
            {
                return await _repository.AddNewSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding specialization: {ex}");
                throw;
            }
        }

        public bool DeleteSpecilization(int specialization)
        {
            return  _repository.DeleteSpecilization(specialization);
        }

        public async Task<IActionResult> GetAll()
        {
            var specializations = await _repository.GetAll();
            var specializeDtos = specializations.Select(s => new SpecializeDto
            {
                Title = s.Title,
               
            }).ToList();

            return new OkObjectResult(specializeDtos);
        }

        public async Task<List<Specialization>> TopSpecilization()
        {
            return await _repository.TopSpecilization();
        }
    }

}

