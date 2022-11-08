using ChallengeBackEnd5.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ChallengeBackEnd5.Profiles;
using ChallengeBackEnd5.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Text.Json.Serialization;
using ChallengeBackEnd5.Secrets;

var builder = WebApplication.CreateBuilder(args);
var secret = builder.Configuration["ConnectionStrings: DbString"];
var secretConfig = builder.Configuration.GetSection("ConnectionStrings").Get<Secrets>();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<videoRepo, videoRepo>();
builder.Services.AddScoped<categoryRepo, categoryRepo>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(secretConfig.DbString));

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
