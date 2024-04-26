using AutoMapper;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDetailsDto>();
            CreateMap<Doctor, DoctorDetailsDTO>();
        }
    }
}
