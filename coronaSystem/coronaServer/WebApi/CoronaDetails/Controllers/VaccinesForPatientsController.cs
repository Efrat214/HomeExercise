using BLL;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesForPatientsController : ControllerBase
    {
        IVaccinesForPatientsBLL vaccinesForPatientsBLL;
        public VaccinesForPatientsController(IVaccinesForPatientsBLL vaccinesForPatientsBLL)
        {
            this.vaccinesForPatientsBLL = vaccinesForPatientsBLL;
        }
        // GET: api/<VaccinesForPatientsController>
        [HttpGet]
        public ActionResult<List<Vaccinesforpatient>> Get()
        {
            return vaccinesForPatientsBLL.GetAllVaccinesforpatients();
        }
        // GET api/<VaccinesForPatientsController>/5
        [HttpGet("GetAllVaccineToPatient/{patientId}")]
        public ActionResult<List<Vaccinesforpatient>> GetAllVaccineToPatient(int patientId)
        {
            var vaccines = vaccinesForPatientsBLL.GetAllVaccineToPatient(patientId);

            if (vaccines == null)
            {
                return NotFound();
            }

            return vaccines;
        }


        [HttpPost]
        public IActionResult Post(Vaccinesforpatient vaccinesforpatient)
        {
            if (ModelState.IsValid)
            {
                // The model is valid, perform further processing

                // Example: Call the BLL to add the vaccines for the patient
                int result = vaccinesForPatientsBLL.AddVaccinesforpatient(vaccinesforpatient);

                // Return appropriate response based on the result
                if (result > 0)
                {
                    return Ok(result); // Success response
                }
                else
                {
                    return StatusCode(500); // Error response
                }
            }
            else
            {
                // The model is not valid, return appropriate validation error response
                return BadRequest(ModelState); // Returns a 400 Bad Request with the validation errors
            }
        }

        //public int Post(Vaccinesforpatient vaccinesforpatient)
        //{
        //    return vaccinesForPatientsBLL.AddVaccinesforpatient(vaccinesforpatient);
        //}
    }
}
