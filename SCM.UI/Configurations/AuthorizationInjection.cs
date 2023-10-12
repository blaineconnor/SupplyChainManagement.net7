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
                    policy.AddRequirements(new RoleAccessRequirement(Role.SuperAdmin));
                });
                opt.AddPolicy("AdminPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.SuperAdmin));
                });
                opt.AddPolicy("PurchasingPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.Purchasing, Role.SuperAdmin));
                });
                opt.AddPolicy("AccountingPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.Accounting, Role.SuperAdmin));
                });
                opt.AddPolicy("SupplierPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.Supplier, Role.SuperAdmin, Role.Purchasing));
                });
                opt.AddPolicy("ManagerPolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.Manager, Role.SuperAdmin));
                });
                opt.AddPolicy("EmployeePolicy", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Role.Admin, Role.Purchasing, Role.Manager, Role.SuperAdmin, Role.Accounting, Role.Employee));
                });

            });

            return services;
        }
    }
}
