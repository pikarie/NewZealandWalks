using NZTrails.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public class StaticUserRepository : IUserRepository
	{
		private List<User> Users = new List<User>()
		{
			new()
			{
				Id = Guid.NewGuid(),
				Username = "username1",
				FirstName = "Jon",
				LastName = "Snow",
				Email = "jon@gmail.com",
				Password = "pAsswOrd#1",
				Roles = new()
				{
					new Role()
					{
						Name = "reader"
					}
				}
			},
			new()
			{
				Id = Guid.NewGuid(),
				Username = "username2",
				FirstName = "Arya",
				LastName = "Stark",
				Email = "arya@gmail.com",
				Password = "pAsswOrd#1",
				Roles = new()
				{
					new Role()
					{
						Name = "reader"
					},
					new Role()
					{
						Name = "writter"
					}
				}
			}
		};

		public async Task<User?> AuthenticateAsync(string username, string password)
		{
			var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
			return user;
		}
	}
}
