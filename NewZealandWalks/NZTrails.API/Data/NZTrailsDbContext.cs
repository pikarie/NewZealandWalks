using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
	public class NZTrailsDbContext : DbContext
	{
		public NZTrailsDbContext(DbContextOptions<NZTrailsDbContext> options): base(options)
		{

		}

		public DbSet<Region> Regions { get; set; }
		public DbSet<Trail> Trails { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}
