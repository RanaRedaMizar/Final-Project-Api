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
        private readonly IUserRepository auth;


        public PatientController(IPatientService patientService, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IUserRepository auth)
        {
            _patientService = patientService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            this.auth = auth;
           

        }


        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetPatients(int page = 1, int pageSize = 2, string search = "")
        {
            try
            {
                var paginatedPatients = _patientService.GetPatients(page, pageSize, search);
                return Ok(paginatedPatients);
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

                var patientDto = new PateintDTO()
                {
                    Id = patient.Id,
                    BirthDate = patient.BirthDate,
                    Image = patient.Image,
                    Gender = patient.Gender,
                    Email = patient.Email,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Phone = patient.PhoneNumber,
                    UserName = patient.UserName,
                   
                };

                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromForm] PateintDTO addPateint)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

              /**  var imageFile = addPateint.ImageFile;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var imagePath = ProcessImageFile(imageFile);
                    addPateint.Image = imagePath;
                }
              **/

                var user = new ApplicationUser
                {
                    FirstName = addPateint.FirstName,
                    LastName = addPateint.LastName,
                    Email = addPateint.Email,
                    Image = addPateint.Image,
                    Phone = addPateint.Phone,
                    UserName = addPateint.UserName,
                    Gender = addPateint.Gender,
                };

                var result = await _userManager.CreateAsync(user, addPateint.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Failed to create Pateint", Errors = result.Errors });
                }

                await _userManager.AddToRoleAsync(user, "Pateint");

                var pateintToAdd = new Patient

        {
            Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Image = user.Image,
                    Phone = user.Phone,
                    Gender = user.Gender,
                    UserName = user.UserName,
                    
                };

                var addPateintResult = _patientService.AddPatient(addPateint);

                if (!addPateintResult)
                {
                    await _userManager.DeleteAsync(user);
                    return BadRequest("Failed to add pateint.");
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
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




        [HttpPost("search")]
        public async Task<IActionResult> SearchPatient([FromForm] string name)
        {
            try
            {
                var pateint = _patientService.SearchPatient(name);

                if (pateint == null)
                {
                    return NotFound();
                }

                var pateintDto = new PateintDTO()
                {
                    Id = pateint.Id,
                    BirthDate = pateint.BirthDate,
                    Image = pateint.Image,
                    Gender = pateint.Gender,
                    Email = pateint.Email,
                    FirstName = pateint.FirstName,
                    LastName = pateint.LastName,
                    Password = pateint.PasswordHash,
                    Phone = pateint.Phone
                };


                return Ok(pateintDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(string id, [FromBody] PateintDTO pateintdtO)
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


