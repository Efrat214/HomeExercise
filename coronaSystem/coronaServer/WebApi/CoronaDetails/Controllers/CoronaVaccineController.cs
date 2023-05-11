using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using EntityFramework;
using System.Diagnostics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaVaccineController : ControllerBase
    {
        ICoronaVaccineBLL CoronaVaccineBLL;
        public CoronaVaccineController(ICoronaVaccineBLL coronaVaccineBLL)
        {
            CoronaVaccineBLL = coronaVaccineBLL;
        }

        // GET: api/<CoronaVaccineController>
        [HttpGet]
        public ActionResult<List<Coronavaccine>> Get()
        {
            return CoronaVaccineBLL.GetAllCoronavaccine();
        }

        // GET api/<CoronaVaccineController>/5
        [HttpGet("{id}")]
        public Coronavaccine Get(int id)
        {
            return CoronaVaccineBLL.GetCoronavaccineById(id);
        }

        // POST api/<CoronaVaccineController>
        [HttpPost]
        public IActionResult Post(Coronavaccine c)
        {
            if (ModelState.IsValid)
            {
                // The model is valid, perform further processing

                // Example: Call the BLL to add the vaccines for the patient
                int result = CoronaVaccineBLL.AddCoronavaccine(c);


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
    }
}
