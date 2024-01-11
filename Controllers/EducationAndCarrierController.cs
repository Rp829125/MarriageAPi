using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarriageAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationAndCarrierController : ControllerBase
    {
        private readonly IEducationAndCarrierService _educationAndCarrierService;
        public EducationAndCarrierController(IEducationAndCarrierService educationAndCarrierService)
        {
            _educationAndCarrierService = educationAndCarrierService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationAndCarrierDto>> GetEducationandCarrierById(int id)
        {
            if (id <= 0) 
            {
                return BadRequest("plese Enter correct Id");

            }
            else
            {
              var data =  await  _educationAndCarrierService.GetEducationAndCarrierByPersonId(id);

                if(data == null)
                {
                    return NotFound(data);
                }

                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEducationAndCarrier(EducationAndCarrierDto DtoData)
        {
            if(ModelState.IsValid) 
            { 
              var result =   await _educationAndCarrierService.AddEducationAndCarrier(DtoData);
                return Ok(result);
            }
            else
            {
                return BadRequest("Please Enter Correct Details");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducationAndCarrier(int id,  EducationAndCarrierDto DtoData)
        {
            if (ModelState.IsValid)
            {
                var result = await _educationAndCarrierService.UpdateEducationAndCarrier(id, DtoData);
                return Ok(result);
            }
            else
            {
                return BadRequest("Plese Enter Valid Details");
            }
        }
        
    }
}
