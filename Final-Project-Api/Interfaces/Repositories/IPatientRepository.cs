using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetPatients(int page, int pageSize, string search);
        Patient GetPatient(string id);
        bool AddPatient(PateintDTO AddedPatientDto);
        bool UpdatePatient(string id, PateintDTO Patient);
        bool DeletePatient(string id);
        Patient SearchPatient(string name);
        int CounPatients();
        void ConfirmCheckup();
    }
}

