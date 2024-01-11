using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MarriageAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiligiousController : ControllerBase
    {
        private readonly IReligiousBackgroundService _ReligiousBackgroundService;
        public RiligiousController(IReligiousBackgroundService ReligiousBackgroundService)
        {
            _ReligiousBackgroundService  = ReligiousBackgroundService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getReligiousDetailsById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            else
            {
                var data =  await _ReligiousBackgroundService.GetReligiousBackGroundByPersonId(id);
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReligiousData(RiligiousBackgroundDto data)
        {
            if (ModelState.IsValid)
            {
                var result = await _ReligiousBackgroundService.AddReiligiousBackground(data);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRiligiousData(int id, RiligiousBackgroundDto data )
        {
           if (ModelState.IsValid)
            {
                var result = await _ReligiousBackgroundService.UpdateReiligiousBackground(id, data);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
       
    }
}
