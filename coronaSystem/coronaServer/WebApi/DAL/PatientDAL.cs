using EntityFramework;

namespace DAL
{
    public class PatientDAL : IPatientDAL
    {
        CoronadetailsDbContext db = new CoronadetailsDbContext();
        public int AddPatient(Patient p)
        {
            db.Patients.Add(p);
            db.SaveChanges();
            return p.Id;
        }

        public List<Patient> GetAllPatients()
        {
            return db.Patients.ToList();
        }

        public Patient GetPatientById(int Id)
        {
            return db.Patients.FirstOrDefault(p => p.Id == Id);
        }
        public Dictionary<DateTime, int> GetAcctivePatientPerDayCount()
        {
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today;
            var counts = new Dictionary<DateTime, int>();

            // Loop through all the patients in the database
            foreach (var patient in db.Patients)
            {
                // If the patient has a positive result
                if (patient.PositiveResultDate.HasValue)
                {
                    // Calculate the end date as the recovery date, or the current date if the patient has not yet recovered
                    var end = patient.RecoveryDate ?? DateTime.Today;

                    // Loop through all the days between the positive result date and the end date
                    for (var date = patient.PositiveResultDate.Value.Date; date <= end.Date; date = date.AddDays(1))
                    {
                        // If the date is within the last 30 days, increment the count for that day
                        if (date >= startDate && date <= endDate)
                        {
                            if (counts.ContainsKey(date))
                            {
                                counts[date]++;
                            }
                            else
                            {
                                counts[date] = 1;
                            }
                        }
                    }
                }
            }

            return counts;
        }
        public int GetNumNotImmune()
        {
            var patientsWithoutVaccines = db.Patients
            .Where(p => !p.Vaccinesforpatients.Any())
             .ToList();

            // Get the count of patients without vaccines
            int countPatientsWithoutVaccines = patientsWithoutVaccines.Count();
            return countPatientsWithoutVaccines;
        }
    }
}
