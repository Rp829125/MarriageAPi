using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace MarriageAPi.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _contextAccessor;
        public PersonController(IPersonService contextAccessor)
        {
            _contextAccessor = contextAccessor ;
        }

        [HttpGet("getDetails")]
        public async Task<List<PersonDto>> GetPersonDetails() 
            {
            var person = await _contextAccessor.GetPerson();
            return person;
            }



        [HttpPost("postDetails")]
        public async Task<ActionResult> AddPesronDetails([FromBody]PersonDto data)
        {
            if(ModelState.IsValid)
            {
                await _contextAccessor.AddPerson(data);
                return Ok("Data is added");

            }
            else
            {
                return BadRequest("plese Types Correct Information");
            }

           
        }



        [HttpGet("getDetails/{id}")]
        public  async Task<PersonDto> GetPerson([FromRoute]int id)
        { 
           if(id == 0)
            {
             throw new ArgumentException("id not found");
                    
             }
            else
            {
              var person = await _contextAccessor.GetPersonById(id);
                return person;
            }

        }



        [HttpDelete("deletePerson/{id}")]
        public async Task DeletePerson([FromRoute]int id)
        { 
         if(id == 0)
            {
                throw new Exception("please enter correct id ");
            }
            else
            {
              await _contextAccessor.DeletePerson(id);
                Ok("data is deleted successfully");
            }
        }


        [HttpPut("updatePersonDetails")]

        public async Task UpdatePersonDetails(PersonDto data)
        {
            if(ModelState.IsValid && data != null)
            {
                await _contextAccessor.updatePersonDetails(data);
                
            }else
            {
                throw new Exception();
            }
        }
    }
}
