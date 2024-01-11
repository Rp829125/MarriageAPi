using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Model
{
    public class ReligiosBackground
    {
        [Key] public int Id { get; set; }
        public  string Religion {  get; set; }
        public  string CastDivision {  get; set; }
        public  string SubCast {  get; set; }

        public  string? Gotra {  get; set; }
        public string? Rashi { get; set; }
        public string? Manglik { get; set; }
          [ForeignKey("IdRef")]
        public int  PersonId { get; set; }
        public PersonDetails IdRef { get; set; }

    }
}
