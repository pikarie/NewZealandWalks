using FluentValidation;
using NZTrails.API.Models.Dto;

namespace NZTrails.API.Validators
{
	public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
	{
		public UserLoginDtoValidator()
		{
			RuleFor(user => user.Username).NotEmpty();
			RuleFor(user => user.Password).NotEmpty();

		}
	}
}
