using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
          [ForeignKey("IdRef")]
        public int  PersonId { get; set; }
        public PersonDetails IdRef { get; set; }
    }
}
