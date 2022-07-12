using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public class RegionRepository : IRegionRepository
	{
		private readonly NZTrailsDbContext context;
		private readonly IMapper mapper;

		public RegionRepository(NZTrailsDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<Region>> GetAllAsync()
		{
			return await context.Regions.ToListAsync();
		}

		public async Task<Region> GetAsync(Guid id)
		{
			return await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Region> AddAsync(Region region)
		{
			region.Id = Guid.NewGuid();

			await context.AddAsync(region);
			await context.SaveChangesAsync();

			return region;
		}

		public async Task<Region?> UpdateAsync(Guid id, Region region)
		{
			var regionInDatabase = await GetAsync(id);

			if (regionInDatabase == null)
			{
				return null;
			}

			mapper.Map(region, regionInDatabase);
			context.Update(regionInDatabase);
			await context.SaveChangesAsync();

			return await GetAsync(id);
		}

		public async Task<Region?> DeleteAsync(Guid id)
		{
			var region = await GetAsync(id);

			if (region == null)
			{
				return null;
			}

			context.Regions.Remove(region);
			await context.SaveChangesAsync();

			return region;
		}
	}
}
