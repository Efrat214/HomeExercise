using DAL;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VaccinesForPatientSBLL : IVaccinesForPatientsBLL
    {
        IVaccinesForPatientsDAL vaccinesForPatientsDAL;
        public VaccinesForPatientSBLL(IVaccinesForPatientsDAL vaccinesForPatientsDAL)
        {
            this.vaccinesForPatientsDAL = vaccinesForPatientsDAL;
        }
 
        public int AddVaccinesforpatient(Vaccinesforpatient v)
        {
            return vaccinesForPatientsDAL.AddVaccinesforpatient(v);
        }

        public List<Vaccinesforpatient> GetAllVaccinesforpatients()
        {
            return vaccinesForPatientsDAL.GetAllVaccinesforpatients();
        }

        public Vaccinesforpatient GetVaccinesforpatientById(int Id)
        {
            return vaccinesForPatientsDAL.GetVaccinesforpatientById(Id);
        }
        public List<Vaccinesforpatient> GetAllVaccineToPatient(int patientId)
        {
            return vaccinesForPatientsDAL.GetAllVaccineToPatient(patientId);
        }
    }
}
