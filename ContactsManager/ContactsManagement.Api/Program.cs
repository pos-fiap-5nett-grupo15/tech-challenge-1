using ContactsManagement.Application.Handlers.Auth;
using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Application.Handlers.Contact.DeleteContactById;
using ContactsManagement.Application.Handlers.Contact.GetContactBydId;
using ContactsManagement.Application.Handlers.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Handlers.Contact.UpdateContactById;
using ContactsManagement.Application.Handlers.User.CreateUser;
using ContactsManagement.Application.Handlers.User.DeleteUser;
using ContactsManagement.Application.Handlers.User.GetUser;
using ContactsManagement.Application.Handlers.User.UpdateUser;
using ContactsManagement.Application.Handlers.User.ValidateUser;
using ContactsManagement.Application.Interfaces.Auth;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.DeleteContactById;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using ContactsManagement.Application.Interfaces.User.CreateUser;
using ContactsManagement.Application.Interfaces.User.DeleteUser;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Application.Interfaces.User.UpdateUser;
using ContactsManagement.Application.Interfaces.User.ValidateUser;
using ContactsManagement.Infrastructure.Crypto;
using ContactsManagement.Infrastructure.Middlewares;
using ContactsManagement.Infrastructure.Settings;
using ContactsManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ContactsManagement.Api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

        ArgumentNullException.ThrowIfNull(jwtSettings);
        ArgumentNullException.ThrowIfNull(jwtSettings.SecretKey);

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        ConfigureAuthentication(builder.Services, jwtSettings.SecretKey);

        builder.Services.AddSingleton<ICryptoService>(new CryptoService());

        ConfigureDatabaseServices(builder.Services, builder.Configuration);
        ConfigureServices(builder.Services);
        ConfigureHandleServices(builder.Services);

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    static public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Contact Manager API",
                Version = "v1",
                Description = "Manager contact API - FIAP Students Project"
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insert token following the pattern: \"Bearer your_authentication_token\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
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
                        },
                    },
                    Array.Empty<string>()
                }
            });
            c.EnableAnnotations();
        });
    }

    static public void ConfigureDatabaseServices(IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped<ITech1Database,Tech1Database>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    static public void ConfigureHandleServices(IServiceCollection services)
    {
        services.AddScoped<ICreateContactHandler, CreateContactHandler>();
        services.AddScoped<IGetContactBydIdHandler, GetContactBydIdHandler>();
        services.AddScoped<IDeleteContactByIdHandler, DeleteContactByIdHandler>();
        services.AddScoped<IUpdateContactByIdHandler, UpdateContactByIdHandler>();
        services.AddScoped<IGetContactListPaginatedByFiltersHandler, GetContatListPaginatedByFiltersHandler>();

        services.AddScoped<IPasswordHandler, PasswordHandler>();
        services.AddScoped<ITokenHandler, Application.Handlers.Auth.TokenHandler>();
        services.AddScoped<ICreateUserHandler, CreateUserHandler>();
        services.AddScoped<IDeleteUserHandler, DeleteUserHandler>();
        services.AddScoped<IGetUserByIdHandler, GetUserByIdHandler>();
        services.AddScoped<IGetUserByNameHandler, GetUserByNameHandler>();
        services.AddScoped<IGetUserListHandler, GetUserListHandler>();
        services.AddScoped<IUpdateUserHandler, UpdateUserHandler>();
        services.AddScoped<IValidateUserHandler, ValidateUserHandler>();
    }

    static public void ConfigureAuthentication(IServiceCollection services, string key)
    {
        var decryptedKey = new CryptoService().Decrypt(key);

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearer =>
        {
            bearer.RequireHttpsMetadata = false;
            bearer.SaveToken = true;
            bearer.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(decryptedKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}