using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Dtos
{
    public class LocationDto
    {
         
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
          
        public int  PersonId { get; set; }
    }
}
