using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.Repository.Repos
{
    public class PersonalDetailsRepos : IPersonalDetailsService
    {
        private readonly AppDbContext _appDbContext;
        public PersonalDetailsRepos(AppDbContext appDbContext)
        {
             _appDbContext = appDbContext;
        }

        public async  Task<string> AddPersonalDetails(PersonalDetailsDto details)
        {
            var modelDetails = new PersonalDetails()
            {
                MaritalStatus = details.MaritalStatus, Height = details.Height, Weight = details.Weight, BodyType = details.BodyType,
                SkinTone = details.SkinTone, PersonId = details.PersonId
                
            };
            await _appDbContext.PersonalDetails.AddAsync(modelDetails);
            await _appDbContext.SaveChangesAsync();

            return "Data Added Successfully";
        }

        public async Task<string> DeletePersonalDetails(int id)
        {
            var details = await _appDbContext.PersonalDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (details != null)
            {
                 _appDbContext.PersonalDetails.Remove(details);
                await _appDbContext.SaveChangesAsync();
                return "Data Added Suuccessfully";
            }
            else
            {
                return "Record Not Found"; 
            }

        }

        public async Task<List<PersonalDetailsDto>> GetPersonalDetails()
        {
            var modelDetails =  await _appDbContext.PersonalDetails.ToListAsync();

            List<PersonalDetailsDto> result = new List<PersonalDetailsDto>();       
                foreach (var details in modelDetails) 
                { 
                    var data = new PersonalDetailsDto()
                    {
                        MaritalStatus = details.MaritalStatus, Height = details.Height, Weight = details.Weight, BodyType = details.BodyType,
                        SkinTone = details.SkinTone,PersonId = details.PersonId
                        
                    };

                   result.Add(data);
                }
                
                  return  result;

        }

        public  async Task<PersonalDetailsDto> GetPesonalDetailsByID(int id)
        {
            var details = await _appDbContext.PersonalDetails.FirstOrDefaultAsync(x => x.PersonId==id);
            if(details == null)
                {
                throw new Exception("Record Not Found");
            }
            else
            {
                var data = new PersonalDetailsDto()
                {
                    MaritalStatus = details.MaritalStatus, Height = details.Height, Weight = details.Weight, BodyType = details.BodyType,
                        SkinTone = details.SkinTone, PersonId = details.PersonId
                   

                };

                return data;
            }
        }

        public async  Task<string> UpdatePersonalDetails(int id ,PersonalDetailsDto details)
        {
            var modelPerson = await _appDbContext.PersonalDetails.FirstOrDefaultAsync(x => x.PersonId == id);
            if(modelPerson == null)
            {
                return "Record not Found, Please Enter COrrect detiails";
            }
            else
            {
                
                modelPerson.MaritalStatus = details.MaritalStatus; 
                modelPerson.Height = details.Height;
                modelPerson.Weight = details.Weight;
                modelPerson.BodyType = details.BodyType;
                modelPerson.SkinTone = details.SkinTone;
                modelPerson.PersonId = details.PersonId;

                await _appDbContext.SaveChangesAsync();

                return "Data Saved Successfully";
            }
        }
    }
}
