using MarriageAPi.Dtos;

namespace MarriageAPi.Repository.Services
{
    public interface IEnquiry
    {
        public Task<List<EnquiryDtos>> GetEnquries();

        public Task<string> DeleteEnquiries( int id);

        public Task<string> AddingEnquiries(EnquiryDtos enquiry);
        

    }
}
