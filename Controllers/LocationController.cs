using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarriageAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService =  locationService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPersonID(int id)
        {
            if (id <= 0) 
            {
                return BadRequest();
            }
            else
            {
            var Location = await _locationService.GetLocationByPersonID(id);
                return Ok(Location);

            }
        }


        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDto locationDto)
        {
            if(ModelState.IsValid)
            {
               var result =  await _locationService.AddLocation(locationDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> updateLocation(int id,LocationDto locationDto)
        {
            if(ModelState.IsValid)
            {
               var result =  await _locationService.UpdateLocation(id,locationDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
