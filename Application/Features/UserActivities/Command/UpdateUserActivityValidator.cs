using Application.DTOs.UserActivityDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserActivities.Command
{
	public class UpdateUserActivityValidator : AbstractValidator<UpdateUserActivityDto>
	{
		public UpdateUserActivityValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.Activity).NotEmpty().MaximumLength(250);
			RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow);
		}
	}
}
