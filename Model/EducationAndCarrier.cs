using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Model
{
    public class EducationAndCarrier
    {
        [Key]
        public int ID { get; set; }
        public string Education { get; set; }
        public string AnnualIncome { get; set; }
        public string WorkLocation { get; set; }
        public string Occupation { get; set; }
        [ForeignKey("IdRef")]
        public int  PersonId { get; set; }

        public PersonDetails IdRef { get; set; }


    }
}
