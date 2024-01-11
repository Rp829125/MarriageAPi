using MarriageAPi.DB_Connection;
using MarriageAPi.Dtos;
using MarriageAPi.Model;
using MarriageAPi.Repository.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarriageAPi.Repository.Repos
{
    public class PersonRepos : IPersonService
    {
        private AppDbContext _appDbContext;


        public PersonRepos(AppDbContext appDbContext) 
        { 
           _appDbContext = appDbContext;
        }



        public async Task<string> DeletePerson(int id)
        {
            var person =  await _appDbContext.PersonDetails.FirstOrDefaultAsync(x => x.Id == id);
            if(person == null)
            {
                return "data not found";
            }
            else
            {

            _appDbContext.PersonDetails.Remove(person);
            await _appDbContext.SaveChangesAsync();
            return "Data is successfully deleted";
            }
        }



        public async Task<List<PersonDto>> GetPerson()
        {
        var personDetails = await _appDbContext.PersonDetails.ToListAsync();

            List<PersonDto> GetPersonContainer = new List<PersonDto>();

            foreach(var person in personDetails) {


                var OnePersonData = new PersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    Age = person.Age,
                    BirthDate = person.BirthDate,
                    MobileNumber = person.MobileNumber,
                    Email = person.Email
                };

                GetPersonContainer.Add(OnePersonData);
            }

            return GetPersonContainer;

        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var person =  await _appDbContext.PersonDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                throw new Exception("user not found");
            }
           
            {
                 var changeDto = new PersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    Age = person.Age,
                    BirthDate = person.BirthDate,
                    MobileNumber = person.MobileNumber,
                    Email = person.Email,
                };

                return changeDto;
            }
        }


        public async Task AddPerson(PersonDto person)
        {
             var matchData = new PersonDetails() 
            {
             Id = person.Id,FirstName = person.FirstName, LastName = person.LastName,Gender=person.Gender,Age = person.Age,BirthDate = person.BirthDate,
             MobileNumber = person.MobileNumber,Email = person.Email
            };

              await _appDbContext.PersonDetails.AddAsync(matchData);
              await  _appDbContext.SaveChangesAsync();
        
        }

        
            public async Task updatePersonDetails(PersonDto person)
            {
            var record =  await _appDbContext.PersonDetails.FirstOrDefaultAsync(x => x.Id == person.Id);
            if (record == null)
            {
                throw new Exception("Record not Found please enter valid Details");
            }
            else
            {
                record.Id = person.Id; record.FirstName = person.FirstName;record.LastName = person.LastName;record.Gender=person.Gender;record.Age = person.Age;record.BirthDate = person.BirthDate;
                record.MobileNumber = person.MobileNumber;record.Email = person.Email;

                await _appDbContext.SaveChangesAsync();
            }
  
            }

       
    }
}
