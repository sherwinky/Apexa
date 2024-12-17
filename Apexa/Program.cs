
using Apexa.DAL;
using Apexa.IDAL;
using Apexa.IService;
using Apexa.IService.Helper;
using Apexa.Service;
using Apexa.Service.Helper;

namespace Apexa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AdvisorContext>();
            builder.Services.AddScoped<IAdvisorDal, AdvisorDal>();
            builder.Services.AddScoped<IAdvisorService, AdvisorService>();
            builder.Services.AddScoped<IValidator, AdvisorValidator>();
            builder.Services.AddSingleton<IUtil,Util>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
