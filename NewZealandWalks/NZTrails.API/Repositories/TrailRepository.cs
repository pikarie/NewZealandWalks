using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public class TrailRepository : ITrailRepository
	{
		private readonly NZTrailsDbContext context;
		private readonly IMapper mapper;

		public TrailRepository(NZTrailsDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<Trail>> GetAllAsync()
		{
			return await context.Trails
				.Include(x => x.Region)
				.Include(x => x.Reviews)
				.ToListAsync();
		}

		public async Task<Trail?> GetAsync(Guid id)
		{
			return await context.Trails
				.Include(x => x.Region)
				.Include(x => x.Reviews)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Trail> AddAsync(Trail trail)
		{
			trail.Id = Guid.NewGuid();

			await context.Trails.AddAsync(trail);
			await context.SaveChangesAsync();

			return trail;
		}

		public async Task<Trail?> UpdateAsync(Guid id, Trail trail)
		{
			var trailInDatabase = await GetAsync(id);

			if (trailInDatabase == null)
			{
				return null;
			}

			mapper.Map(trail, trailInDatabase);
			context.Update(trailInDatabase);
			await context.SaveChangesAsync();

			return await GetAsync(id);
		}

		public async Task<Trail?> DeleteAsync(Guid id)
		{
			var trail = await GetAsync(id);

			if (trail == null)
			{
				return null;
			}

			context.Trails.Remove(trail);
			await context.SaveChangesAsync();

			return trail;
		}
	}
}
