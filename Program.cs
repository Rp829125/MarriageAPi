
using MarriageAPi.DB_Connection;
using MarriageAPi.Repository.Repos;
using MarriageAPi.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;

namespace MarriageAPi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            

            var builder = WebApplication.CreateBuilder(args);

            /*these is FormatException cors Resolve*/
            
            

            builder.Services.AddCors(options =>
            {
            
            options.AddPolicy("AllowOrigin",
                builder => builder
                    .AllowAnyOrigin()    // You can specify specific origins instead of allowing any origin
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
                
            

            
            // working with Databse Here
            builder.Services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );
            builder.Services.AddScoped<IPersonService, PersonRepos>();
            builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsRepos>();
            builder.Services.AddScoped<IFamilyDetailsService, FamilyDetailsRepos>();
            builder.Services.AddScoped<ILocationService, LocationRepos>();
            builder.Services.AddScoped<IEducationAndCarrierService, EducationAndCarrierRepos>();
            builder.Services.AddScoped<IReligiousBackgroundService, RiligiousBackgroundRepos>();
            builder.Services.AddScoped<IEnquiry,EnquiriesRepos>();

            // Add services to the container.s
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("AllowOrigin");
            }

            

            app.UseHttpsRedirection();
                    
            app.UseAuthorization();

         

            app.MapControllers();

            app.Run();
        }
    }
}
