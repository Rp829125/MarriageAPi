using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.Repository.Repos
{
    public class EnquiriesRepos : IEnquiry
    {
        private readonly AppDbContext _appDbContext;
        public EnquiriesRepos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public  async Task<string> AddingEnquiries(EnquiryDtos enquiry)
        {
          var EnquiryData = new Enquiry
          {
              Id = enquiry.Id, Name = enquiry.Name, City = enquiry.City, Email = enquiry.Email, Gender = enquiry.Gender,
              IntrestedProfileId = enquiry.IntrestedProfileId, IntrestedProfileName = enquiry.IntrestedProfileName, Phone=enquiry.Phone,
          };

          await _appDbContext.Enquiry.AddAsync(EnquiryData);
            await _appDbContext.SaveChangesAsync();

            return "Enquiries are saved successfully";
        }



        public async Task<string> DeleteEnquiries(int id)
        {
            var enquiries = await  _appDbContext.Enquiry.FirstOrDefaultAsync(x => x.Id == id);
            if (enquiries == null)
            {
                return "no record  found";
            }
            else
            {
                _appDbContext.Remove(enquiries);
                await _appDbContext.SaveChangesAsync();
                return "Data is deleted ";
            }
        }



        public async  Task<List<EnquiryDtos>> GetEnquries()
        {
           var enquireis  =  await _appDbContext.Enquiry.ToListAsync();

           var enquiriesDto = new List<EnquiryDtos>();

            foreach (var enquiry in enquireis)
            {
              var dtoData =  new EnquiryDtos
                {
                    Id = enquiry.Id,
                    Name = enquiry.Name,
                    City = enquiry.City,
                    Email = enquiry.Email,
                    Gender = enquiry.Gender,
                    IntrestedProfileId = enquiry.IntrestedProfileId,
                    IntrestedProfileName = enquiry.IntrestedProfileName,
                    Phone = enquiry.Phone,
                };
                
               enquiriesDto.Add(dtoData);  
            }
        
            return enquiriesDto;
           
        }
    }
}
