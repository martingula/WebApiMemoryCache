using WebApiMemoryCache.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

var services = builder.Services;

// Add services to the container.
services.AddMemoryCache();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Add in memory database
services.AddDbContext<AppDbContext>
    (o => o.UseInMemoryDatabase("VehicleDb"));

// Add app services
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettingModel>();
services.AddSingleton(apiSettings ?? new ApiSettingModel());
services.AddSingleton<ICacheService, CacheService>();
services.AddScoped<IVehicleService, VehicleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
