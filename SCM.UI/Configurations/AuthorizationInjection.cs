using Microsoft.AspNetCore.Authorization;
using SCM.UI.Authorization;
using static SCM.UI.Models.Enumarations;

namespace SCM.UI.Configurations
{
    public static class AuthorizationInjection
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, SessionBasedAccessHandler>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("SuperAdminPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.SuperAdmin));
                });
                opt.AddPolicy("AdminPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.SuperAdmin));
                });
                opt.AddPolicy("PurchasingPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.Purchasing, Authorizations.SuperAdmin));
                });
                opt.AddPolicy("AccountingPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.Accounting, Authorizations.SuperAdmin));
                });
                opt.AddPolicy("SupplierPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.Supplier, Authorizations.SuperAdmin, Authorizations.Purchasing));
                });
                opt.AddPolicy("ManagerPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.Manager, Authorizations.SuperAdmin));
                });
                opt.AddPolicy("EmployeePolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Authorizations.Admin, Authorizations.Purchasing, Authorizations.Manager, Authorizations.SuperAdmin, Authorizations.Accounting, Authorizations.Employee));
                });

            });

            return services;
        }
    }
}
