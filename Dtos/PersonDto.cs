﻿using System.ComponentModel.DataAnnotations;

namespace MarriageAPi.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set;}
        public string MobileNumber { get; set;}
        public string? Email { get; set;}
    }
}
