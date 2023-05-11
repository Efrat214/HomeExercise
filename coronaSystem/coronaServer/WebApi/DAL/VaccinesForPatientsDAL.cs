using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VaccinesForPatientsDAL : IVaccinesForPatientsDAL
    {
        CoronadetailsDbContext db = new CoronadetailsDbContext();

        public int AddVaccinesforpatient(Vaccinesforpatient v)
        {
            var patient = db.Patients.Find(v.PatientId);
            var vaccine = db.Coronavaccines.Find(v.VaccineId);

            if (patient != null && vaccine != null)
            {
                // Set the related entities
                v.Patient = patient;
                v.Vaccine = vaccine;

                // Add the Vaccinesforpatient entity to the context
                db.Vaccinesforpatients.Add(v);

                // Save changes to the database
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<Vaccinesforpatient> GetAllVaccinesforpatients()
        {
            return db.Vaccinesforpatients.ToList();
        }

        public Vaccinesforpatient GetVaccinesforpatientById(int Id)
        {
            return db.Vaccinesforpatients.FirstOrDefault(v=>v.Id==Id);
        }
        public List<Vaccinesforpatient> GetAllVaccineToPatient(int patientId)
        {
            var vaccines = db.Vaccinesforpatients
                .Include(v => v.Vaccine) // eager load the vaccine entity
                .Where(v => v.PatientId == patientId)
                .Select(v => new Vaccinesforpatient
                {
                    Id = v.Id,
                    PatientId = v.PatientId,
                    VaccineId = v.VaccineId,
                    Dateofvaccination = v.Dateofvaccination,
                    Patient = v.Patient,
                    Vaccine = new Coronavaccine
                    {
                        Id = v.Vaccine.Id,
                        Manufacturer = v.Vaccine.Manufacturer
                    }
                })
                .ToList();

            return vaccines;
        }
    }
}
