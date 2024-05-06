using AutoMapper;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Services;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserRepository auth;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IApplicationUserRepository auth, IMapper mapper)
        {
            _patientService = patientService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            this.auth = auth;
            _mapper = mapper;
        }


        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetPatients(int page = 1, int pageSize = 2, string search = "")
        {
            try
            {
                var paginatedPatients = _patientService.GetPatients(page, pageSize, search);
                var response = _mapper.Map<List<PatientDetailsDto>>(paginatedPatients);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




        [HttpGet("patientsCount")]
        public async Task<IActionResult> CounPatients()
        {
            try
            {
                var count = _patientService.CounPatients();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatient(string id)
        {
            try
            {
                var patient = _patientService.GetPatient(id);

                if (patient == null)
                {
                    return NotFound();
                }

                var patientDto = new PatientDetailsDto()
                {
                    Id = patient.Id,
                    BirthDate = patient.BirthDate,
                    Image = patient.Image,
                    Gender = patient.Gender,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Address = patient.Address,
                    Phone = patient.PhoneNumber,
                };

                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                Image = request.Image,
                Phone = request.Phone,
                Address = request.Address,
                Gender = request.Gender
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Failed to create Pateint", Errors = result.Errors });
            }

            // to update patient specific info like Age as user manager only inserts user specific columns
            var updateSucceeded = _patientService.UpdatePatient(user.Id, request);
            if (!updateSucceeded)
                return BadRequest();

            return Ok();
        }


        private string ProcessImageFile(IFormFile imageFile)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return $"/images/{uniqueFileName}";
        }


        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(string id, [FromBody] PatientDto pateintdtO)
        {
            try
            {
                var result = _patientService.UpdatePatient(id, pateintdtO);

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


        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            try
            {
                var result = _patientService.DeletePatient(id);

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


