using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
		private readonly IReviewRepository reviewRepository;
		private readonly IMapper mapper;

		public ReviewsController(IReviewRepository reviewRepository, IMapper mapper)
        {
			this.reviewRepository = reviewRepository;
			this.mapper = mapper;
		}

        // GET: api/Reviews
        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews()
        {
            var reviews = await reviewRepository.GetAllAsync();

            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<ReviewDto>>(reviews));
        }

        // GET: api/Reviews/5
        [HttpGet("{id:guid}")]
        [ActionName(nameof(GetReview))]
        [Authorize(Roles = "reader")]
        public async Task<ActionResult<ReviewDto>> GetReview(Guid id)
        {
            var review = await reviewRepository.GetAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ReviewDto>(review));
        }

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "reader")]
        public async Task<ActionResult<ReviewDto>> PostReview(AddReviewDto addReviewDto)
        {
            //TODO: add validation

            var review = mapper.Map<Review>(addReviewDto);
            var newReview = await reviewRepository.AddAsync(review);
            var reviewDto = mapper.Map<ReviewDto>(newReview);

            return CreatedAtAction(nameof(GetReview), new { id = reviewDto.Id }, reviewDto);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> PutReview(Guid id, UpdateReviewDto updateReviewDto)
        {
            //TODO: add validation

            var updatedReview = await reviewRepository.UpdateAsync(id, updateReviewDto);

            if (updatedReview == null)
            {
                return NotFound();
            }

            return Ok(updateReviewDto);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var review = await reviewRepository.DeleteAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            var reviewDto = mapper.Map<ReviewDto>(review);
            return Ok(reviewDto);
        }
    }
}
