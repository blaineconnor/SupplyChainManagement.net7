using FluentValidation;
using FluentValidation.AspNetCore;
using SCM.UI.Validators.Accounts;

namespace SCM.UI.Configurations
{
    public static class FluentValidationInjection
    {
        public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

            return services;
        }
    }
}
