using FluentValidation;
using NZTrails.API.Models.Dto;

namespace NZTrails.API.Validators
{
	public class AddReviewDtoValidator : AbstractValidator<AddReviewDto>
	{
		public AddReviewDtoValidator()
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
