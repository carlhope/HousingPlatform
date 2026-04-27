using FluentValidation;
using Housing.Api.Features.Properties;
using Housing.Api.Features.Properties.Create;
using Housing.Domain.Entities;
using Housing.Infrastructure.Behaviours;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HousingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var apiAssembly = typeof(Program).Assembly;
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    return ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false");

});

builder.Services.AddSingleton<ICacheService, RedisCacheService>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(apiAssembly);
});

builder.Services.AddValidatorsFromAssembly(apiAssembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Housing API is running");
app.MapPropertyEndpoints();

app.Run();