using Microsoft.AspNetCore.Authentication.Cookies;
using SCM.UI.Configurations;
using SCM.UI.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opt => {
    opt.ModelValidatorProviders.Clear();
    opt.Filters.Add(new ActionExceptionFilter());
});

builder.Services.AddHttpContextAccessor();

//Fluent Validation
builder.Services.AddFluentValidationService();

//Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Session
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(20);
});

//Custom Services
builder.Services.AddDIServices();

//Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    opt =>
    {
        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("admin"))
                {
                    context.Response.Redirect("/admin/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("superadmin"))
                {
                    context.Response.Redirect("/superadmin/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("purchasing"))
                {
                    context.Response.Redirect("/purchasing/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("manager"))
                {
                    context.Response.Redirect("/manager/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("supplier"))
                {
                    context.Response.Redirect("/supplier/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("employee"))
                {
                    context.Response.Redirect("/employee/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

        opt.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                if (context.Request.Path.Value.Contains("accounting"))
                {
                    context.Response.Redirect("/accounting/login/signin");
                }
                else
                {
                    context.Response.Redirect("/Account/SignIn");
                }
                return Task.CompletedTask;
            }
        };

    });


//Authorization
builder.Services.AddAuthorizationService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "superadmin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "purchasing",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "manager",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "supplier",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "employee",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "accounting",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();