using FluentValidation;
using NZTrails.API.Models.Dto;

namespace NZTrails.API.Validators
{
	public class UpdateReviewDtoValidator : AbstractValidator<UpdateReviewDto>
	{
		public UpdateReviewDtoValidator()
		{
			RuleFor(review => review.Rating).NotEmpty();

			//var trail = await trailRepository.GetAsync(reviewDto.TrailId);
			//if (trail == null)
			//{
			//	ModelState.AddModelError(nameof(reviewDto.TrailId), $"(custom message!) {nameof(reviewDto.TrailId)} is invalid.");
			//}
		}
	}
}
