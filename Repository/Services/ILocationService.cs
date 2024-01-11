using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface ILocationService
    {
        Task<string> AddLocation(LocationDto location);
     Task<string> UpdateLocation(int id,LocationDto location);
     Task<LocationDto> GetLocationByPersonID(int id);
    }
}
