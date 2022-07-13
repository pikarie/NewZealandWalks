//TODO: refactor validator to use interfaces and reuse similar RuleFor in multiple validator classes.
//TODO: Add units tests to this solution.

using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NZTrails.API.Repositories;
using NZTrails.API.Validators;
using NZWalks.API.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	 .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation(options =>
{
	options.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.AddDbContext<NZTrailsDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("NZTrails"));
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddAutoMapper(typeof(Program));

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
