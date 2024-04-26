using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }


        public bool AddPatient(PatientDto pateintDTO)
        {
            try
            {
                if (pateintDTO != null)
                {
                    var patient = new Patient
                    {
                        FirstName = pateintDTO.FirstName,
                        LastName = pateintDTO.LastName,
                        Email = pateintDTO.Email,
                        BirthDate = pateintDTO.BirthDate,
                        Image = pateintDTO.Image,
                        Gender = pateintDTO.Gender,
                        Phone = pateintDTO.Phone,
                        Address = pateintDTO.Address,

                    };

                    _context.Patients.Add(patient);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding patient: {ex}");
                return false;
            }
        }


        public void ConfirmCheckup()
        {
            throw new NotImplementedException();
        }

        public int CounPatients()
        {
            return _context.Patients.Count();
        }


        public bool DeletePatient(string id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Patient GetPatient(string id)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Id == id);
            return patient;
        }



        public List<Patient> GetPatients(int page, int pageSize, string search)
        {
            var allPatients = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allPatients = allPatients
                      .Where(patient =>
                        patient.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || patient.LastName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            var paginatedPatients = allPatients
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return paginatedPatients;
        }

        public Patient SearchPatient(string name)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.FirstName == name);

            return patient;
        }

        public bool UpdatePatient(string id, PatientDto updatedPatient)
        {
            var currentPatient = _context.Patients.FirstOrDefault(d => d.Id == id);

            if (currentPatient != null)
            {
                currentPatient.FirstName = updatedPatient.FirstName;
                currentPatient.LastName = updatedPatient.LastName;
                currentPatient.Email = updatedPatient.Email;
                currentPatient.Phone = updatedPatient.Phone;
                currentPatient.Gender = updatedPatient.Gender;
                currentPatient.Address = updatedPatient.Address;
                currentPatient.BirthDate = updatedPatient.BirthDate;
                currentPatient.Age = updatedPatient.Age;

                _context.Patients.Update(currentPatient);

                _context.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
