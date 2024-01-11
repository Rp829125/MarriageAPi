using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Dtos
{
    public class FamilyDetailsDto
    {
    
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string? MotherOccupation { get; set; }
        public string? BrotherProfile { get; set; }
        public string? SisterProfile { get; set; }
        public string? FamilyType {get; set; }
         
         public int  PersonId { get; set; }
    }
}
