﻿using Amazon;
using Amazon.DynamoDBv2;
using ConciergeBackend.Controllers;
using ConciergeBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
clientConfig.RegionEndpoint = RegionEndpoint.EUCentral1;
builder.Services.AddSingleton(new AmazonDynamoDBClient(clientConfig));


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
