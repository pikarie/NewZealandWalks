using NZTrails.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface IUserRepository
	{
		Task<User?> AuthenticateAsync(string username, string password);
	}
}
