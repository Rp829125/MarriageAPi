using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.Repository.Repos
{
    public class FamilyDetailsRepos :IFamilyDetailsService
    {
        private readonly AppDbContext _appDbContext;

    public FamilyDetailsRepos (AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<FamilyDetailsDto> GetFamilyDetailsByPersonId(int personId)
    {
       
        var familyDetails = await _appDbContext.ParentDetails.FirstOrDefaultAsync(fd => fd.PersonId == personId);

                if(familyDetails != null)
                {
                    var  changeDto =  new FamilyDetailsDto()
                    {
                  FatherName = familyDetails.FatherName,
                  MotherName = familyDetails.MotherName,
                  FatherOccupation = familyDetails.FatherOccupation,
                  MotherOccupation = familyDetails.MotherOccupation,
                  BrotherProfile = familyDetails.BrotherProfile,
                  SisterProfile = familyDetails.SisterProfile,
                  FamilyType = familyDetails.FamilyType,
                  PersonId = familyDetails.PersonId
                    };

                    return changeDto;
                 }
                else
                {
                    return null; 
                }
       
    }

    public async Task<string> AddFamilyDetails(FamilyDetailsDto familyDetailsDto)
    {
        var familyDetails = new ParentDetails
        {
            FatherName = familyDetailsDto.FatherName,
            MotherName = familyDetailsDto.MotherName,
            FatherOccupation = familyDetailsDto.FatherOccupation,
            MotherOccupation = familyDetailsDto.MotherOccupation,
            BrotherProfile = familyDetailsDto.BrotherProfile,
            SisterProfile = familyDetailsDto.SisterProfile,
            FamilyType = familyDetailsDto.FamilyType,
            PersonId = familyDetailsDto.PersonId
        };

        await _appDbContext.ParentDetails.AddAsync(familyDetails);
        await _appDbContext.SaveChangesAsync();

        return "Family Details Added Successfully";
    }

        public async  Task<string> UpdateFamilyDetails(int id, FamilyDetailsDto familyDetailsDto)
        {
            var familyDetails = await _appDbContext.ParentDetails.FirstOrDefaultAsync(x => x.PersonId == id);

            if(familyDetails != null)
            {
            familyDetails.FatherName = familyDetailsDto.FatherName;
            familyDetails.MotherName = familyDetailsDto.MotherName;
            familyDetails.FatherOccupation = familyDetailsDto.FatherOccupation;
            familyDetails.MotherOccupation = familyDetailsDto.MotherOccupation;
            familyDetails.BrotherProfile = familyDetailsDto.BrotherProfile;
            familyDetails.SisterProfile = familyDetailsDto.SisterProfile;
            familyDetails.FamilyType = familyDetailsDto.FamilyType;
            familyDetails.PersonId = familyDetailsDto.PersonId;

                await _appDbContext.SaveChangesAsync();

                return "changes are saved";
            }
            else { 
                return "record are not found";
                    
                    
                    }
        }
    }
}
