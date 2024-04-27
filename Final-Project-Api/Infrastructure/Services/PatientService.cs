using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Repositories;
using Final_Project_Api.Interfaces.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;

namespace Final_Project_Api.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public bool AddPatient(PatientDto Pateint)
        {
            return _patientRepository.AddPatient(Pateint);
        }

        public void ConfirmCheckup()
        {
            throw new NotImplementedException();
        }

        public int  CounPatients()
        {
            return _patientRepository.CounPatients();;

        }

        public bool DeletePatient(string id)
        {
            return _patientRepository.DeletePatient(id);

        }

        public Patient GetPatient(string id)
        {
            return _patientRepository.GetPatient(id);

        }

        public List<Patient> GetPatients(int page, int pageSize, string search)
        {
            return _patientRepository.GetPatients(page, pageSize, search);

        }

        public Patient SearchPatient(string name)
        {
            return _patientRepository.SearchPatient(name);

        }


        public bool UpdatePatient(string id, PatientDto Patient)
        {
            return _patientRepository.UpdatePatient(id, Patient);
        }


    }
}

