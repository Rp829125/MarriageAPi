using Azure.Identity;
using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.Repository.Repos
{
    public class RiligiousBackgroundRepos : IReligiousBackgroundService
    {
        private readonly AppDbContext _appDbContext;
        public RiligiousBackgroundRepos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddReiligiousBackground(RiligiousBackgroundDto DtoData)
        {
            var modelData = new ReligiosBackground()
            {
               Religion=DtoData.Religion, CastDivision=DtoData.CastDivision, SubCast=DtoData.SubCast, Gotra=DtoData.Gotra, Rashi=DtoData.Rashi, 
               PersonId = DtoData.PersonId, Manglik=DtoData.Manglik, 
            };
            await _appDbContext.AddAsync(modelData);
            await _appDbContext.SaveChangesAsync();

            return "Data is Added successfully";
        }

        public async  Task<RiligiousBackgroundDto> GetReligiousBackGroundByPersonId(int personId)
        {
            var DtoData =  await _appDbContext.ReligiosBackground.FirstOrDefaultAsync(x => x.PersonId == personId);

            if (DtoData == null)
            {
                return null;
            }
            else
            {
                var RiligiousDto = new RiligiousBackgroundDto()
                {
                Religion=DtoData.Religion, CastDivision=DtoData.CastDivision, SubCast=DtoData.SubCast, Gotra=DtoData.Gotra, Rashi=DtoData.Rashi, 
                PersonId = DtoData.PersonId, Manglik=DtoData.Manglik

                };

                return RiligiousDto;
            }
        }

        public  async Task<string> UpdateReiligiousBackground(int id, RiligiousBackgroundDto DtoData)
        {
            var modelData = await _appDbContext.ReligiosBackground.FirstOrDefaultAsync(x => x.PersonId==id);
            if(modelData == null)
            {
                return "Record Not Found";
            }
            else
            {
                modelData.Religion=DtoData.Religion;
                modelData.CastDivision=DtoData.CastDivision;
                modelData.SubCast=DtoData.SubCast;
                modelData.Gotra=DtoData.Gotra;
                modelData.Rashi=DtoData.Rashi;
                modelData.PersonId = DtoData.PersonId;
                modelData.Manglik=DtoData.Manglik;

                await _appDbContext.SaveChangesAsync();
                return "Data is successfully Updated";
            }
        }
    }
}
