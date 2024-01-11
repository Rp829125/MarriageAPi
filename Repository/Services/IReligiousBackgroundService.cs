using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface IReligiousBackgroundService
    {
        Task<RiligiousBackgroundDto> GetReligiousBackGroundByPersonId(int personId);
        Task<string> AddReiligiousBackground(RiligiousBackgroundDto DtoData);
        Task<string> UpdateReiligiousBackground(int id,RiligiousBackgroundDto DtoData );
    }
}
