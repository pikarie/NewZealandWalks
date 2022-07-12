using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
		Task<Region> GetAsync(Guid id);
		Task<Region> AddAsync(Region region);
		Task<Region?> UpdateAsync(Guid id, UpdateRegionDto updateRegionDto);	
		Task<Region?> DeleteAsync(Guid id);
	}
}
