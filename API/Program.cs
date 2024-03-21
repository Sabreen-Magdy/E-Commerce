using Presentation;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Services.DataServices;
using Persistence.Repositories;
using Domain.Repositories.Customer;
using Services.Abstraction.DataServices.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Add Services

string corsName = "openAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsName,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var connection = builder.Configuration.GetConnectionString("online");
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connection, b => b.MigrationsAssembly("Persistence")));

// Add Controllers 
builder.Services.AddControllers().AddApplicationPart(
     typeof(AssemblyReferneces).Assembly);

// Add Services Scope
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
