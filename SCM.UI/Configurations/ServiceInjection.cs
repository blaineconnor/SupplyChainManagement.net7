using SCM.UI.Services.Abstraction;
using SCM.UI.Services.Implementation;

namespace SCM.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();

            return services;
        }
    }
}
