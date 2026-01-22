using Application.DTOs.UserDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Command
{
	public class BaseUserValidator : AbstractValidator<CreateUserDto>  // يمكنك أن تجعلها قاعدة لمشاركة القواعد بين `CreateUserDto` و `UpdateUserDto`
	{
		public BaseUserValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.EmailAddress().WithMessage(localizer["InvalidEmail"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MinimumLength(6).WithMessage(localizer["PasswordMinLength"]);

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.Matches(@"^218(91|92|94)\d{7}$").WithMessage(localizer["InvalidPhoneNumberFormat"]);
		}
	}
}
