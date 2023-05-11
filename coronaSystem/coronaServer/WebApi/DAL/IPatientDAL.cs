using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPatientDAL
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int Id);

        int AddPatient(Patient p);
        public Dictionary<DateTime, int> GetAcctivePatientPerDayCount();
        public int GetNumNotImmune();
    }
}
