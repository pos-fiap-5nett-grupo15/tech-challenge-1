using ContactsManagement.Application.Handlers.Contact.CreateContact;
using ContactsManagement.Application.Handlers.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Domain.Repositories;
using ContactsManagement.Infrastructure.Data;
using ContactsManagement.Infrastructure.Middlewares;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Api;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);
        ConfigureDatabaseServices(builder.Services);
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
        services.AddSwaggerGen();
    }

    static public void ConfigureDatabaseServices(IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IContactRepository, ContactRepository>();
    }

    static public void ConfigureHandleServices(IServiceCollection services)
    {
        services.AddScoped<ICreateContactHandler, CreateContactHandler>();
        services.AddScoped<IGetContactBydIdHandler, GetContactBydIdHandler>();
    }
}