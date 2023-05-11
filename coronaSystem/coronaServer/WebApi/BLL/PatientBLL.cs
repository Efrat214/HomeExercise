using DAL;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatientBLL:IPatientBLL
    {
        IPatientDAL patientDAL;
        public PatientBLL(IPatientDAL patientDAL)
        {
            this.patientDAL = patientDAL;
        }

        public int AddPatient(Patient p)
        {
            return patientDAL.AddPatient(p);
        }

        public List<Patient> GetAllPatients()
        {
            return patientDAL.GetAllPatients();
        }

        public Patient GetPatientById(int Id)
        {
            return patientDAL.GetPatientById(Id);
        }
        public Dictionary<DateTime, int> GetAcctivePatientPerDayCount()
        {
            return patientDAL.GetAcctivePatientPerDayCount();
        }
        public int GetNumNotImmune()
        {
            return patientDAL.GetNumNotImmune();
        }

    }
}
