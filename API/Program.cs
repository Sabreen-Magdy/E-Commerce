using Presentation;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using Domain.Repositories;
using Services;
using Persistence.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Services.Abstraction;
using Services.Authentication;
using Persistence.OtherConfiguration;
using Domain.External;
using Persistence.ExternalConfiguration;
using Persistence.External;
using Services.Abstraction.External;
using Services.External;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

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


// Add Controllers 
builder.Services.AddControllers().AddApplicationPart(
     typeof(AssemblyReferneces).Assembly);

// Add Services Scope
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IExternalRepository, ExternalRepository>();
builder.Services.AddScoped<IExrernalService, ExrernalService>();


//// Add Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(op =>
    {
        op.RequireHttpsMetadata = false;
        op.TokenValidationParameters = new TokenValidationParameters
          {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
          };
    });


builder.Services.AddIdentity<ApplicationIdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders(); ;

var connection = builder.Configuration.GetConnectionString("soomcon");
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    options/*.UseLazyLoadingProxies()*/.UseSqlServer(
        connection, b => b.MigrationsAssembly("Persistence")));
#endregion

var app = builder.Build();
app.UseCors(corsName);
app.UseSwagger();
app.UseSwaggerUI(); 

app.UseCors(corsName);
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
//app.UseMvc();

app.MapControllers();

app.Run();
