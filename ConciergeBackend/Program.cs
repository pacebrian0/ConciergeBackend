using ConciergeBackend.Controllers;
using ConciergeBackend.Controllers.Interfaces;
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
builder.Services.AddControllers();

builder.Services.AddScoped<IAuditLogic, AuditLogic>();
builder.Services.AddScoped<IAuditData, AuditData>();

builder.Services.AddScoped<IHistoryLogic, HistoryLogic>();
builder.Services.AddScoped<IHistoryData, HistoryData>();

builder.Services.AddScoped<IHostLogic, HostLogic>();
builder.Services.AddScoped<IHostData, HostData>();

builder.Services.AddScoped<IPropertyLogic, PropertyLogic>();
builder.Services.AddScoped<IPropertyData, PropertyData>();

builder.Services.AddScoped<IReservationLogic, ReservationLogic>();
builder.Services.AddScoped<IReservationData, ReservationData>();

builder.Services.AddScoped<IRoomLogic, RoomLogic>();
builder.Services.AddScoped<IRoomData, RoomData>();

builder.Services.AddScoped<IStaffUserLogic, StaffUserLogic>();
builder.Services.AddScoped<IStaffUserData, StaffUserData>();

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IUserData, UserData>();


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
