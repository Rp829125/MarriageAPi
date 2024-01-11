using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface IPersonalDetailsService
    {   Task<List<PersonalDetailsDto>> GetPersonalDetails();
        Task<PersonalDetailsDto> GetPesonalDetailsByID(int id);
        Task<string> AddPersonalDetails(PersonalDetailsDto details);
        Task<string> UpdatePersonalDetails(int id,PersonalDetailsDto details);
        Task<string> DeletePersonalDetails(int id);
    }
}
