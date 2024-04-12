using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Services;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisTypeController : ControllerBase
    {
        private readonly IAnalysisTypeService _analysisTypeService;
        private readonly AppDbContext _dbContext;
        public AnalysisTypeController(IAnalysisTypeService analysisTypeService, AppDbContext dbContext)
        {
            _analysisTypeService = analysisTypeService;
            _dbContext = dbContext;
        }

        [HttpGet("GetAllAnalysisType")]
        public async Task<IActionResult> GetAll()
        {


            try
            {
                var result = await _analysisTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

        }




        [HttpPost("AddAnalysisType")]
        public async Task<IActionResult> AddNewAnalysisType([FromForm] AnalysisTypeDTO analysisType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var analysisTypeToAdd = new AnalysisType
                {
                    Name = analysisType.Name,
                    Description = analysisType.Description,


                };

                var result = _analysisTypeService.AddNewAnalysisType(analysisTypeToAdd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

      
        [HttpDelete("DeleteAnalysisType")]
        public async Task<IActionResult> DeleteAnalysisType(int id)
        {
            try
            {
                var result = _analysisTypeService.DeleteAnalysisType(id);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




    }
}

