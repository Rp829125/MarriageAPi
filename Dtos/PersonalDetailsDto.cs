using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageAPi.Dtos
{
    public class PersonalDetailsDto
    {
        
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string? Weight { get; set; }
        public string? BodyType { get; set; }
        public string? SkinTone { get; set; }

        public int PersonId { get; set; }
    }
}
