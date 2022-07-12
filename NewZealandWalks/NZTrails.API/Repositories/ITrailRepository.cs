using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface ITrailRepository
	{
		Task<IEnumerable<Trail>> GetAllAsync();
		Task<Trail?> GetAsync(Guid id);
		Task<Trail> AddAsync(Trail trail);
		Task<Trail?> UpdateAsync(Guid id, UpdateTrailDto updateTrailDto);
		Task<Trail?> DeleteAsync(Guid id);
	}
}
