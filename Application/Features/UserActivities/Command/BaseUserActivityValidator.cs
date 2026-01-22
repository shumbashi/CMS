using Application.DTOs.UserActivityDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserActivities.Command
{
	public class BaseUserActivityValidator : AbstractValidator<CreateUserActivityDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseUserActivityValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(localizer["UserIdRequired"]);

			RuleFor(x => x.Activity)
				.NotEmpty().WithMessage(localizer["ActivityRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Date)
				.NotEmpty().WithMessage(localizer["DateRequired"]);
		}
	}
}
