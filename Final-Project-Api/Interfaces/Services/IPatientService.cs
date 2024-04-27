using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients(int page, int pageSize, string search);
        Patient GetPatient(string id);
        bool AddPatient(PatientDto AddedPatientDto);
        bool UpdatePatient(string id, PatientDto Patient);
        bool DeletePatient(string id);
        Patient SearchPatient(string name);
        int CounPatients();
        void ConfirmCheckup();
    }
}
