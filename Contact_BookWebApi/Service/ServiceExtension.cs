using ContactBook_Infrastructure.Repository;
using ContactBooks_Application.Services;
using ContactBooks_Infrastructure.Repository;

namespace Contact_BookWebApi.Service
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            });
        }
        public static void DependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IContactImplementation, ContactImplementation>();
            services.AddScoped<IContactRepository, ContactRepository>();

        }
    }
}