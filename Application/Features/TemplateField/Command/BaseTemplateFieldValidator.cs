using Application.DTOs.TemplateFieldDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.TemplateField.Command
{
	public class BaseTemplateFieldValidator : AbstractValidator<CreateTemplateFieldDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseTemplateFieldValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.FieldName)
				.NotEmpty().WithMessage(localizer["FieldNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.ExpectedDataType)
				.NotEmpty().WithMessage(localizer["ExpectedDataTypeRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.FieldDescription)
				.MaximumLength(500).WithMessage(localizer["MaxLengthIs500"]);

			RuleFor(x => x.Template)
				.NotNull().WithMessage(localizer["TemplateRequired"]);
		}
	} 
}
