using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MarriageAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquriesController : ControllerBase
    {
        private readonly IEnquiry _enquiry;
        public EnquriesController(IEnquiry enquiry)
        {
            _enquiry = enquiry;
        }

        [HttpGet()]
        public  async Task<ActionResult<List<EnquiryDtos>>> Get() 
        {
         var enquiryData = await _enquiry.GetEnquries();
            return Ok(enquiryData);
            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEnquirie(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

           var result =  await _enquiry.DeleteEnquiries(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddEnquiry(EnquiryDtos data)
        {
            if (ModelState.IsValid)
            {
              var result =   await _enquiry.AddingEnquiries(data);
               return Ok(result);
            }

            return BadRequest();    
        }
    }
}
