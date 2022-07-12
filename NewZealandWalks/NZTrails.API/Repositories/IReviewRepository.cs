using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public interface IReviewRepository
	{
		Task<IEnumerable<Review>> GetAllAsync();
		Task<Review> GetAsync(Guid id);
		Task<Review> AddAsync(Review review);
		Task<Review?> UpdateAsync(Guid id, UpdateReviewDto updateReviewDto);
		Task<Review?> DeleteAsync(Guid id);
	}
}
