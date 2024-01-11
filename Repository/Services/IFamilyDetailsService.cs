using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface IFamilyDetailsService
    {
        Task<FamilyDetailsDto> GetFamilyDetailsByPersonId(int personId);
        Task<string> AddFamilyDetails(FamilyDetailsDto familyDetailsDto);
        Task<string> UpdateFamilyDetails(int id,FamilyDetailsDto familyDetailsDto);
    }
}
