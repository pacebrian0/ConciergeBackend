using Amazon;
using Amazon.DynamoDBv2;
using ConciergeBackend.Controllers;
using ConciergeBackend.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AmazonDynamoDBConfig clientConfig = new()
{
    RegionEndpoint = RegionEndpoint.EUCentral1
};
builder.Services.AddSingleton(new AmazonDynamoDBClient(clientConfig));
builder.Services.AddTransient(x =>
  new MySqlConnection(builder.Configuration.GetConnectionString("MariaDbConnectionString")));
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
