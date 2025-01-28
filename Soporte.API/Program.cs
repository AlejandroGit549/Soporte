using Serilog.Events;
using Serilog;
using Soporte.API.Middleware;
using Soporte.Application;
using Soporte.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Nivel mínimo de logs
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information) // Filtra logs de Microsoft
    .Enrich.FromLogContext() // Enriquecer logs con contexto
    .WriteTo.Console() // Escribe logs en la consola
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Escribe logs en archivos
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
