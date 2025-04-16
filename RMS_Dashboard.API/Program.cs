using FluentValidation.AspNetCore;
using RMS_Dashboard.API.Middlewares;
using RMS_Dashboard.Core;
using RMS_Dashboard.Core.Mappers;
using RMS_Dashboard.Infrastructure;
using System.Text.Json.Serialization;

namespace RMS_Dashboard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Infrastructure services
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();

            // Add controllers to the service collection
            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile));

            //FluentValidations
            builder.Services.AddFluentValidationAutoValidation();


            // Add controllers to the service collection
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseExceptionHandlingMiddleware();
           
            //Routing
            app.UseRouting();

            //Auth
            app.UseAuthentication();
            app.UseAuthorization();

            //Controller Routing
            app.MapControllers();


            app.Run();
        }
    }
}
