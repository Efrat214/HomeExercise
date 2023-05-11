using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPatientBLL
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int Id);

        int AddPatient(Patient p);
        public Dictionary<DateTime, int> GetAcctivePatientPerDayCount();
        public int GetNumNotImmune();
    }
}
