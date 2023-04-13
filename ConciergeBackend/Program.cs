using ConciergeBackend.Controllers;
using ConciergeBackend.Data;
using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuditLogic, AuditLogic>();
builder.Services.AddScoped<IAuditData, AuditData>();


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
