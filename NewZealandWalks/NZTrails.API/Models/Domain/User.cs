using System.ComponentModel.DataAnnotations.Schema;

namespace NZTrails.API.Models.Domain
{
	public class User
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[NotMapped]
		public List<Role> Roles { get; set; } = new List<Role>();
		public List<User_Role> UserRoles { get; set; }
	}
}
