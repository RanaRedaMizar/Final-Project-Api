using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Enums;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }


        public bool AddDoctor(DoctorDTO doctorDto)
        {
            try
            {
                if (doctorDto != null)
                {
                    var doctor = new Doctor
                    {
                        FirstName = doctorDto.FirstName,
                        LastName = doctorDto.LastName,
                        Email = doctorDto.Email,
                        BirthDate = doctorDto.BirthDate,
                        Image = doctorDto.Image,
                        Gender = doctorDto.Gender,
                        Phone = doctorDto.Phone,
                        Address = doctorDto.Address,
                      //  UserName = doctorDto.UserName,
                        SpecializeId = doctorDto.SpecializeId,

                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor: {ex}");
                return false;
            }
        }


        public void ConfirmCheckup()
        {
            throw new NotImplementedException();
        }

        public int CountDoctors()
        {
            return _context.Doctors.Count();
        }


        public bool DeleteDoctor(string id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Doctor GetDoctor(string id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor;
        }



        public List<Doctor> GetDoctors(int page, int pageSize, string search)
        {
            var allDoctors = _context.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allDoctors = allDoctors
                      .Where(patient =>
                        patient.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || patient.LastName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            var paginatedDoctors = allDoctors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return paginatedDoctors;
        }

        public Doctor SearchDoctor(string name)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.FirstName == name);

            return doctor;
        }

        public List<Doctor> TopDoctors()
        {
            //var topdocs = _context.Doctors
            //    .OrderByDescending(d=>d.Bookings.Count())
            //    .Take(5)
            //    .ToList();

            //return topdocs;
            throw new NotImplementedException();

        }

        public bool UpdateDoctor(string id, DoctorDTO updatedDoctor)
        {
            var currentDoctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (currentDoctor != null)
            {
                currentDoctor.FirstName = updatedDoctor.FirstName;
                currentDoctor.LastName = updatedDoctor.LastName;
                currentDoctor.Phone = updatedDoctor.Phone;
                currentDoctor.Gender = updatedDoctor.Gender;
                currentDoctor.Address = updatedDoctor.Address;
                currentDoctor.BirthDate = updatedDoctor.BirthDate;
                currentDoctor.SpecializeId = updatedDoctor.SpecializeId;

                _context.Doctors.Update(currentDoctor);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
