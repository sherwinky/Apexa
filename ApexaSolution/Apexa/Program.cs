
using Apexa.DAL;
using Apexa.Filters;
using Apexa.IDAL;
using Apexa.IService;
using Apexa.IService.Helper;
using Apexa.Service;
using Apexa.Service.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace Apexa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod() 
                            .WithHeaders("authorization", "accept", "content-type", "origin");
                    });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            SetupDi(builder);

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorHandlingFilterAttribute));
            });
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        private static void SetupDi(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AdvisorContext>();
            builder.Services.AddScoped<IAdvisorDal, AdvisorDal>();
            builder.Services.AddScoped<IAdvisorService, AdvisorService>();
            builder.Services.AddScoped<IValidator, AdvisorValidator>();
            builder.Services.AddSingleton<IUtil, Util>();
        }
    }
}
