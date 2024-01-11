using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Model
{
    public class ParentDetails
    {
        [Key]
        public int Id {get;set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string? MotherOccupation { get; set; }
        public string? BrotherProfile { get; set; }
        public string? SisterProfile { get; set; }
        public string? FamilyType {get; set; }
          [ForeignKey("personId")]
         public int  PersonId { get; set; }
        public PersonDetails personId { get; set; }


    }
}
