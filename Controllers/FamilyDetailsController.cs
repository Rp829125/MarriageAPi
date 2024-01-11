using MarriageAPi.Dtos;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarriageAPi.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class FamilyDetailsController : ControllerBase
{
    private readonly IFamilyDetailsService _familyDetailsService;

    public FamilyDetailsController(IFamilyDetailsService familyDetailsService)
    {
        _familyDetailsService = familyDetailsService;
    }

    [HttpGet("{personId}")]
    public async Task<IActionResult> GetDetails(int personId)
    {
       if(personId <= 0)
       {
         return BadRequest();      
       }

        var familyDetailsDto = await _familyDetailsService.GetFamilyDetailsByPersonId(personId);


        if (familyDetailsDto == null)
        {
            return NotFound();
        }

        return Ok(familyDetailsDto);
    }

    [HttpPost]
    public async Task<IActionResult> PostDetails([FromBody] FamilyDetailsDto familyDetailsDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _familyDetailsService.AddFamilyDetails(familyDetailsDto);

        return Ok(result);
    }

        [HttpPut("{personId}")]
    public async Task<IActionResult> UpdateFamilyTask(int personId, FamilyDetailsDto data) 
    { 
           if(ModelState.IsValid)
            {
               var result =  await _familyDetailsService.UpdateFamilyDetails(personId, data);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
    }
}

}
