using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net;

namespace MarriageAPi.Repository.Repos
{
    public class LocationRepos : ILocationService
    {
        private readonly AppDbContext _dbContext;
        public LocationRepos(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<string> AddLocation(LocationDto locationDto)
        {
            var locationModel = new Location
            {
                Address = locationDto.Address, City = locationDto.City, State = locationDto.State, Country = locationDto.Country,
                PersonId = locationDto.PersonId
            };

             await _dbContext.Location.AddAsync(locationModel);
            await _dbContext.SaveChangesAsync();
            return "Location Data is saved ";
        }


        public async  Task<LocationDto> GetLocationByPersonID(int id)
        {
            var ModelLocation = await _dbContext.Location.FirstOrDefaultAsync(x => x.PersonId == id);
            if (ModelLocation == null) 
            { 
                return null;
            }
            else
            { 
                var location = new LocationDto
                {
                Address = ModelLocation.Address, City = ModelLocation.City, State = ModelLocation.State, Country = ModelLocation.Country,
                PersonId = ModelLocation.PersonId
                };
                    
                return location;
            }
        }


        public async  Task<string> UpdateLocation( int id,LocationDto locationDto)
        {
            var ModelLocation = await _dbContext.Location.FirstOrDefaultAsync(x => x.PersonId == id);

            if (ModelLocation == null)
            {
                return "Record Not Found";
            }
            else
            {
                ModelLocation.Address = locationDto.Address;
                ModelLocation.City = locationDto.City;
                ModelLocation.State = locationDto.State;
                ModelLocation.Country = locationDto.Country;
                ModelLocation.PersonId = locationDto.PersonId;

                await _dbContext.SaveChangesAsync();

                return "Location Data Changes Successfully";
            }
            
        }
    }
}
