using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface IEducationAndCarrierService
    {
        Task<EducationAndCarrierDto> GetEducationAndCarrierByPersonId(int id);
        Task<string> AddEducationAndCarrier(EducationAndCarrierDto EducationAndCarrier);
        Task<string> UpdateEducationAndCarrier(int id,EducationAndCarrierDto EducationAndCarrier) ;
    }
}
