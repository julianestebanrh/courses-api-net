using MasterNet.Application;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.FileUpload.Cloudinary;
using MasterNet.Infrastructure.Reports;
using MasterNet.Persistence;
using MasterNet.WebApi.Extensions;
using MasterNet.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddPoliciesServices();

// Mapeo de propiedades
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));

builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddSwaggerDocumentation();


builder.Services.AddCors(x => x.AddPolicy("CorsApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.useSwaggerDocumentation();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsApp");

await app.ConfigureAuthenticationData();

app.Run();

// Ejecutar las migraciones
// dotnet ef --verbose migrations add InitialMigration -p src/MasterNet.Persistence -s src/MasterNet.WebApi

// Iniciar con la configuracion del launchSettings.json
// dotnet run --project src/MasterNet.WebApi

// Iniciar en un entorno especifico 
// dotnet run --project src/MasterNet.WebApi --environment "Development"
// dotnet run --project src/MasterNet.WebApi --environment "Staging"
// dotnet run --project src/MasterNet.WebApi --environment "Production"

