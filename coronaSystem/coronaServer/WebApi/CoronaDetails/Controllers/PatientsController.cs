using BLL;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        IPatientBLL patientBLL;
        public PatientsController(IPatientBLL patientBLL)
        {
            this.patientBLL = patientBLL;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public ActionResult<List<Patient>> Get()
        {
            return patientBLL.GetAllPatients();
        }

        // GET api/<PatientsController>/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return patientBLL.GetPatientById(id);
        }

        //POST api/<PatientsController>
        [HttpPost]
        public IActionResult Post(Patient p)
        { 

            if (!IsCellPhone(p.Mobilephone))
            {
                ModelState.AddModelError("Phone", "Invalid Israeli phone number");
            }

            if (!LegalId(p.PatientId))
            {
                ModelState.AddModelError("Id", "Invalid Israeli ID");
            }
            if (!IsValidIsraelStationaryPhoneNumber(p.Telephone))
            {
                ModelState.AddModelError("Telephone", "Invalid Israeli telephone number");
            }
            if (p.PositiveResultDate >= p.RecoveryDate||p.PositiveResultDate>DateTime.Now||p.RecoveryDate>DateTime.Now)
            {
                ModelState.AddModelError("Dates", "Invalid positive and recovery date");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // All validations passed, proceed with saving the patient
            int result = patientBLL.AddPatient(p);
            return Ok(result);
        }
        //this service gets a file and if its type of image it saves it in the project directory.
        [HttpPost("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null || file.Length != 0 || file.ContentType.StartsWith("image/"))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { filePath });
            }
            return BadRequest("Invalid file upload");

        }
        //this service returns how many active people were in the last 30 dayes.
        [HttpGet("positivecases")]
        public Dictionary<DateTime, int> Getpositivecases()
        {
            return patientBLL.GetAcctivePatientPerDayCount();
        }
        //this service return how many people are not Vaccinated
        [HttpGet("NotImmune")]
        public int GetNumNotImmune()
        {
            return patientBLL.GetNumNotImmune();
        }
        public static bool IsCellPhone(string tel)
        {
            string pattern = @"^(972|0|05)([23489]|5[02489]|77)[1-9]\d{6}$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(tel);
        }
        public static bool IsValidIsraelStationaryPhoneNumber(string phoneNumber)
        {
            // Regex pattern for Israeli stationary phone number
            string pattern = @"^(972|0)([23489]|77)[1-9]\d{6}$";

            // Check if the phone number matches the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool LegalId(string s)//תז תקין
        {
            int x;
            if (!int.TryParse(s, out x))
                return false;
            if (s.Length < 5 || s.Length > 9)
                return false;
            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            return sum % 10 == 0;
        }
    }
}
