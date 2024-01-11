using MarriageAPi.Model;
using Microsoft.EntityFrameworkCore;

namespace MarriageAPi.DB_Connection
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonDetails> PersonDetails { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<ParentDetails> ParentDetails { get; set; } 

        public DbSet<ReligiosBackground> ReligiosBackground { get; set;}
        public DbSet<EducationAndCarrier> EducationAndCarrier { get; set; }
        public DbSet<Location> Location { get; set; }

        public DbSet<Enquiry> Enquiry { get; set; }


    }
}
