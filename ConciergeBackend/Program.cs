using ConciergeBackend.Controllers;
using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Data;
using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using NuGet.Packaging;
using Swashbuckle.AspNetCore.Filters;
using System.Drawing;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddControllers();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

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
/*
else
{
    app.UseHttpsRedirection();


}
*/
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});


app.UseAuthorization();

app.MapControllers();

app.Run();
