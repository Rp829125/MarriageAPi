using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.Repository.Repos
{
    public class EducationAndCarrierRepos : IEducationAndCarrierService
    {
        private readonly AppDbContext _dbContext;
        public EducationAndCarrierRepos(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<string> AddEducationAndCarrier(EducationAndCarrierDto DtoData)
        {
           var modelEduCationAndCarrier = new EducationAndCarrier
           {
               Education=DtoData.Education, AnnualIncome=DtoData.AnnualIncome, Occupation=DtoData.Occupation, WorkLocation=DtoData.WorkLocation,
               PersonId=DtoData.PersonId
           };

           await _dbContext.EducationAndCarrier.AddAsync(modelEduCationAndCarrier);
            await _dbContext.SaveChangesAsync();

            return "Education and Carrier Data are Added";
        }

        public async  Task<EducationAndCarrierDto> GetEducationAndCarrierByPersonId(int id)
        {
            var DtoData =  await _dbContext.EducationAndCarrier.FirstOrDefaultAsync(x => x.PersonId == id);

           if(DtoData == null)
            {
                return null;

            }
            else
            {
                var result = new EducationAndCarrierDto()
                {
                    Education=DtoData.Education, AnnualIncome=DtoData.AnnualIncome, Occupation=DtoData.Occupation, WorkLocation=DtoData.WorkLocation,
                    PersonId=DtoData.PersonId
           
                };

                return result;
            }

        }

        public async  Task<string> UpdateEducationAndCarrier(int id, EducationAndCarrierDto DtoData)
        {
            var modelData =  await _dbContext.EducationAndCarrier.FirstOrDefaultAsync(x => x.PersonId == id);

           if(modelData == null)
            {
                return null;

            }
            else
            { 
                modelData.Education=DtoData.Education;
                modelData.AnnualIncome=DtoData.AnnualIncome;
                modelData.Occupation=DtoData.Occupation;
                modelData.WorkLocation=DtoData.WorkLocation;
                modelData.PersonId=DtoData.PersonId;

                await _dbContext.SaveChangesAsync();

                return " Eduaction and Carrier Data Added successfully";
                    

               
            }
        }
    }
}
