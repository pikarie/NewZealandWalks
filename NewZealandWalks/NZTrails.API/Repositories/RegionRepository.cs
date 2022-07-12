using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public class RegionRepository : IRegionRepository
	{
		private readonly NZTrailsDbContext context;

		public RegionRepository(NZTrailsDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Region>> GetAllAsync()
		{
			return await context.Regions.ToListAsync();
		}
	}
}
