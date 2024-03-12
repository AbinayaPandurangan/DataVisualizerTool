using Microsoft.EntityFrameworkCore;
using Serilog;
using Snow.DataVisualizer.API.Repositories;
using Snow.DataVisualizer.API.Repositories.DataContexts;
using Snow.DataVisualizer.API.Repositories.Interface;


var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Logger = logger;
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

builder.Services.AddScoped<IDataVisualizerRepository, DataVisualizerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(opt =>
{
    opt.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();

try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.Error(ex, "A problem occured during migration.");
}

app.Run();
