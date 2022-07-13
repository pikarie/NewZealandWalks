using Microsoft.EntityFrameworkCore;
using NZTrails.API.Models.Domain;
using NZWalks.API.Data;

namespace NZTrails.API.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly NZTrailsDbContext context;

		public UserRepository(NZTrailsDbContext context)
		{
			this.context = context;
		}

		public async Task<User?> AuthenticateAsync(string username, string password)
		{
			var user = await context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() &&
				x.Password == password);

			if (user == null)
			{
				return null;
			}

			var userRoles = await context.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

			foreach (var userRole in userRoles)
			{
				var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
				if (role != null)
				{
					user.Roles.Add(role);
				}
			}

			//O.O sketchy code there in the course.
			user.Password = null;

			return user;
		}
	}
}
