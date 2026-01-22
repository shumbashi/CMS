using Application.DTOs.TemplateDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class BaseTemplateValidator : AbstractValidator<CreateTemplateDto> // قاعدة مشتركة بين Create و Update
	{
		public BaseTemplateValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.TemplateName)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.TemplateStatus)
				.NotEmpty().WithMessage(localizer["NotEmpty"]);
		}
	}
}
