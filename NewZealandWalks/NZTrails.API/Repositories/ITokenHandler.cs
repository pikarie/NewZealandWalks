using NZTrails.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface ITokenHandler
	{
		Task<string> CreateTokenAsync(User user);
	}
}
