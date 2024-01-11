using System.ComponentModel.DataAnnotations;

namespace MarriageAPi.Model
{
    public class PersonDetails
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set;}
        public string MobileNumber { get; set;}
        public string? Email { get; set;}
        public  PersonalDetails PersonalDetails { get; set; }
        public ReligiosBackground ReligiosBackground { get; set; }  
        public ParentDetails ParentDetails { get; set; }
        public EducationAndCarrier EducationAndCarrier { get; set;}
        public Location Location { get; set;}

            


    }

}
