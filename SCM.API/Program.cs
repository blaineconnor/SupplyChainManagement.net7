﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SCM.API.Filters;
using SCM.Application.AutoMappings;
using SCM.Application.Services.Abstractions;
using SCM.Application.Services.Implementations;
using SCM.Application.Validators.Categories;
using SCM.Domain.Repositories;
using SCM.Domain.Services.Abstractions;
using SCM.Domain.Services.Implementation;
using SCM.Domain.UnitofWork;
using SCM.Persistence.Context;
using SCM.Persistence.Repositories;
using SCM.Persistence.UnitofWork;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

Log.Logger.Information("Program Started...");

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                        },
                            new string[] {}
                    }
                });
});

builder.Services.AddHttpContextAccessor();

//DbContext Registiration
builder.Services.AddDbContext<SCM_Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SupplyChainManagement"));
});

//Repository Registiraction
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//UnitOfWork Registiration
builder.Services.AddScoped<IUnitWork, UnitWork>();

//Business Service Registiration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestDetailService, RequestDetailService>();

//Automapper
builder.Services.AddAutoMapper(typeof(DomaintoDTO), typeof(VMtoDomain));



// JWT kimlik doðrulama servisini ekleme
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Tokený oluþturan tarafýn adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Tokenýn kullanýlacaðý hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Kalýcý olarak saklanacak dosyalar için kayýt yeri ayarlanýyor.
app.UseStaticFiles();

app.Run();