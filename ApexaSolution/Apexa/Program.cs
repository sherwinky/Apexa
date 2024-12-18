
using Apexa.DAL;
using Apexa.Filters;
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
            builder.Services.AddScoped<IAdvisorDal,AdvisorDal>();
            builder.Services.AddScoped<IAdvisorService, AdvisorService>();
            builder.Services.AddScoped<IValidator, AdvisorValidator>();
            builder.Services.AddSingleton<IUtil,Util>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorHandlingFilterAttribute));
            });
            var app = builder.Build();
            app.UseCors("MyAllowOrigins");

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
