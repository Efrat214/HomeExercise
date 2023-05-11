using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IVaccinesForPatientsDAL
    {
        List<Vaccinesforpatient> GetAllVaccinesforpatients();
        Vaccinesforpatient GetVaccinesforpatientById(int Id);

        int AddVaccinesforpatient(Vaccinesforpatient v);
        List<Vaccinesforpatient> GetAllVaccineToPatient(int patientId);
    }
}
