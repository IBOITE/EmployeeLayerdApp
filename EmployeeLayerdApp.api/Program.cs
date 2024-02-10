using NLog;
using NLog.Web;
using Employee.Application;
using Employee.Data;
using Employee.Data.RepositoryBase;
using Employee.Repositroy.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using EmployeeLayerdApp.api.Authenticaton;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("init main");

try
{


var builder = WebApplication.CreateBuilder(args);


// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
);
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, BasicAuthenticaionHandler>("Basic", null);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
}
catch(Exception ex)
{
    logger.Error(ex);
}
finally
{
    LogManager.Shutdown();
}
