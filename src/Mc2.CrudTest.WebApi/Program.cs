
using FluentValidation;
using FluentValidation.AspNetCore;
using Mc2.CrudTest.Application.Features.Commands;
using Mc2.CrudTest.Application.Features.Validations;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Infra.Persistance;
using Mc2.CrudTest.Infra.ReposImpl;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString, connection =>
    {
        connection.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
        connection.CommandTimeout(60);
    });
    options.EnableDetailedErrors();
});
var sp = builder.Services.BuildServiceProvider();
sp.GetRequiredService<AppDbContext>().Database.Migrate();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPhoneNumberValidator, PhoneNumberValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000, x => x.Protocols = HttpProtocols.Http1);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
