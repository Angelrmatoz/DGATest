using DGAPrueba.Core.Application;
using DGAPrueba.Infrastructure.Persistence;
using DGAPrueba.Presentation.Api.Extensions;
using sDGAPrueba.Infrastructure.Identity;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence Layer
builder.Services.AddPersistenceLayer(builder.Configuration);

//Application Layer
builder.Services.AddApplicationLayer();

//Identity Layer
builder.Services.AddIdentityInfrastructure(builder.Configuration);

//services extension
builder.Services.AddSwaggerExtension();

builder.Services.AddControllers();



// CORS configuration
builder.Services.AddCors(options =>
    options.AddPolicy("NewPolicy", app =>
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //Swagger default route
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

//enable CORS
app.UseCors("NewPolicy");

// add this line to enable authentication
app.UseAuthentication();
app.UseAuthorization();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}