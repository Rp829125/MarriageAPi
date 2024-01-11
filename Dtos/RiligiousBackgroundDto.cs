using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Dtos
{
    public class RiligiousBackgroundDto
    {
  
        [Required]
        public  string Religion {  get; set; }
        public  string CastDivision {  get; set; }
        public  string SubCast {  get; set; }

        public  string? Gotra {  get; set; }
        public string? Rashi { get; set; }
        public string? Manglik { get; set; }
          
        public int  PersonId { get; set; }
    }
}
