using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace MarriageAPi.Model
{
    public class Enquiry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }   
        public string Email { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
       
        public int  IntrestedProfileId { get; set; }
         public string IntrestedProfileName { get; set; }
        
    }
}
