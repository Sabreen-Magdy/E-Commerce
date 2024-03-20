using Customer.Domain.Repositories;
using Customer.Persistence.Client;
using Customer.Persistence.Context;
using Customer.Persistence.Repositories;
using Customer.Presentation;
using Customer.Services.Abst.DataServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string corsName = "openAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsName,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});
#region Add Services

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var connection = builder.Configuration.GetConnectionString("mosCon");
builder.Services
    .AddDbContext<CustomerContext>(options =>
    options.UseSqlServer(
        connection, b => b.MigrationsAssembly("Persistence")));

// Add Controllers 
builder.Services.AddControllers().AddApplicationPart(
    typeof(AssemblyReferneces).Assembly);

// Add HttpClients

builder.Services.AddHttpClient<FavouriteClient>(client =>
{
    client.BaseAddress = new Uri("");
});
builder.Services.AddHttpClient<OrderClient>(client =>
{
    client.BaseAddress = new Uri("");
});
builder.Services.AddHttpClient<CartClient>(client =>
{
    client.BaseAddress = new Uri("");
});

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
