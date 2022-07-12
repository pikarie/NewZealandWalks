using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZTrails.API.Models.Dto;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly NZTrailsDbContext context;
		private readonly IMapper mapper;

		public ReviewRepository(NZTrailsDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<Review>> GetAllAsync()
		{
			return await context.Reviews.ToListAsync();
		}

		public async Task<Review> GetAsync(Guid id)
		{
			return await context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Review> AddAsync(Review review)
		{
			review.Id = Guid.NewGuid();

			await context.AddAsync(review);
			await context.SaveChangesAsync();

			return review;
		}

		public async Task<Review?> UpdateAsync(Guid id, UpdateReviewDto updateReviewDto)
		{
			var reviewInDatabase = await GetAsync(id);

			if (reviewInDatabase == null)
			{
				return null;
			}
			var reviewToUpdate = mapper.Map(updateReviewDto, reviewInDatabase);

			context.Update(reviewToUpdate);
			await context.SaveChangesAsync();

			return await GetAsync(id);
		}

		public async Task<Review?> DeleteAsync(Guid id)
		{
			var review = await GetAsync(id);

			if (review == null)
			{
				return null;
			}

			context.Reviews.Remove(review);
			await context.SaveChangesAsync();

			return review;
		}

	}
}
