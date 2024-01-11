using MarriageAPi.Dtos;
using MarriageAPi.Model;

namespace MarriageAPi.Repository.Services
{
    public interface IPersonService
    {
        Task AddPerson(PersonDto person);
        Task<List<PersonDto>> GetPerson();
        Task<string> DeletePerson(int id);
        Task<PersonDto> GetPersonById(int id);
        Task updatePersonDetails(PersonDto data);
        


    }
}
