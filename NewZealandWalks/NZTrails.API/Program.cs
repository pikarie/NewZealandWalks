//TODO: refactor validator to use interfaces and reuse similar RuleFor in multiple validator classes.
//TODO: Add units tests to this solution.

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NZTrails.API.Repositories;
using NZTrails.API.Validators;
using NZWalks.API.Data;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	 .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var securityScheme = new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Description = "Enter a valid JWT bearer token.",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		Reference = new OpenApiReference
		{
			Id = JwtBearerDefaults.AuthenticationScheme,
			Type = ReferenceType.SecurityScheme
		}
	};

	options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			securityScheme, new string[] { }
		}
	});

});

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
builder.Services.AddScoped<ITokenHandler, NZTrails.API.Repositories.TokenHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddSingleton<IUserRepository, StaticUserRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
