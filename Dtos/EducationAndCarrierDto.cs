using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Dtos
{
    public class EducationAndCarrierDto
    {
        
        public string Education { get; set; }
        public string AnnualIncome { get; set; }
        public string WorkLocation { get; set; }
        public string Occupation { get; set; }
     
        public int  PersonId { get; set; }
    }
}
