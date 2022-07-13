using Microsoft.IdentityModel.Tokens;
using NZTrails.API.Models.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZTrails.API.Repositories
{
	public class TokenHandler : ITokenHandler
	{
		private readonly IConfiguration configuration;

		public TokenHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public Task<string> CreateTokenAsync(User user)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.GivenName, user.FirstName),
				new Claim(ClaimTypes.Surname, user.LastName),
				new Claim(ClaimTypes.Email, user.Email),
			};

			user.Roles.ForEach(role =>
			{
				claims.Add(new Claim(ClaimTypes.Role, role.Name));
			});

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				configuration["Jwt:Issuer"],
				configuration["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddHours(5),
				signingCredentials: credentials
			);

			return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
		}
	}
}
