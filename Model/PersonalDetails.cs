using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Model
{
    public class PersonalDetails
    {
        [Key]
        public int Id { get; set; }
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string? Weight { get; set; }
        public string? BodyType { get; set; }
        public string? SkinTone { get; set; }
          [ForeignKey("IdRef")]
        public int  PersonId { get; set; }
        public PersonDetails? IdRef { get; set; } 
    }
}
