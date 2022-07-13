using FluentValidation;
using NZTrails.API.Models.Dto;

namespace NZTrails.API.Validators
{
	public class AddRegionDtoValidator : AbstractValidator<AddRegionDto>
	{
		public AddRegionDtoValidator()
		{
			RuleFor(region => region.Code).NotEmpty();
			RuleFor(region => region.Name).NotEmpty();
			RuleFor(region => region.Area).GreaterThanOrEqualTo(0);
			RuleFor(region => region.Latitude).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
			RuleFor(region => region.Longitude).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
			RuleFor(region => region.Population).GreaterThanOrEqualTo(0);
		}
	}
}
