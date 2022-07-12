using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
	}
}
