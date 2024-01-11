using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsService _personalDetailsServicea;
        public PersonalDetailsController(IPersonalDetailsService personalDetailsServicea) 
            {
             _personalDetailsServicea = personalDetailsServicea;

            }

        [HttpGet]
        public async Task<ActionResult<List<PersonalDetailsDto>>> GetPersonalDetails() 
            {
                var personalDetails = await _personalDetailsServicea.GetPersonalDetails();
                return Ok(personalDetails);
            }

        [HttpPost]
        public async Task<IActionResult> AddPersonDetails(PersonalDetailsDto data)
        {
            if(ModelState.IsValid)
            {
                 await _personalDetailsServicea.AddPersonalDetails(data);
                return Ok("data is Added");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalDetailsDto>> GetPersonalDetailsById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var person =  await _personalDetailsServicea.GetPesonalDetailsByID(id);
               
                return Ok(person); 

            }
        }
        
    }
}
