using Microsoft.EntityFrameworkCore;
using NZTrails.API.Models.Domain;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
	public class NZTrailsDbContext : DbContext
	{
		public NZTrailsDbContext(DbContextOptions<NZTrailsDbContext> options): base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User_Role>()
				.HasOne(x => x.Role)
				.WithMany(x => x.UserRoles)
				.HasForeignKey(x => x.RoleId);

			modelBuilder.Entity<User_Role>()
				.HasOne(x => x.User)
				.WithMany(x => x.UserRoles)
				.HasForeignKey(x => x.UserId
			);
		}

		public DbSet<Region> Regions { get; set; }
		public DbSet<Trail> Trails { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User_Role> Users_Roles { get; set; }
	}
}
