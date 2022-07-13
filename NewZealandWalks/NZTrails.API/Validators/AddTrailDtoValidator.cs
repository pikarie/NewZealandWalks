using FluentValidation;
using NZTrails.API.Models.Dto;

namespace NZTrails.API.Validators
{
	public class AddTrailDtoValidator : AbstractValidator<AddTrailDto>
	{
		public AddTrailDtoValidator()
		{
			RuleFor(trail => trail.Name).NotEmpty();

			//var region = await regionRepository.GetAsync(trailDto.RegionId);
			//if (region == null)
			//{
			//	ModelState.AddModelError(nameof(trailDto.RegionId), $"(custom message!) {nameof(trailDto.RegionId)} is invalid.");
			//}
		}
	}
}
