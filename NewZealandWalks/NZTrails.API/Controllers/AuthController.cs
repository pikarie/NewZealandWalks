using Microsoft.AspNetCore.Mvc;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;

namespace NZTrails.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly ITokenHandler tokenHandler;

		public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
		{
			this.userRepository = userRepository;
			this.tokenHandler = tokenHandler;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(UserLoginDto userLoginDto)
		{
			var user = await userRepository.AuthenticateAsync(userLoginDto.Username, userLoginDto.Password);

			if (user != null)
			{ 
				var token = await tokenHandler.CreateTokenAsync(user);
				return Ok(token);
			}

			return BadRequest("You have entered an invalid username or password.");
		}
	}
}
