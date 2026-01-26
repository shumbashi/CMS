using Application.DTOs.TemplateDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class UpdateTemplateValidator : AbstractValidator<UpdateTemplateDto>
	{
		public UpdateTemplateValidator(IStringLocalizer<SharedResources> localizer)
		{
			// إضافة قواعد التحقق لـ TemplateName
			RuleFor(x => x.TemplateName)
				.NotEmpty().WithMessage(localizer["NameRequired"])  // التحقق من أن الاسم غير فارغ
				.MaximumLength(100).WithMessage(localizer["NameMaxLength"]);  // التحقق من الحد الأقصى للطول

			// إضافة قواعد التحقق لـ TemplateDescription
			RuleFor(x => x.TemplateStatus)
				.NotEmpty().WithMessage(localizer["TemplateStatusRequired"]);  // التحقق من أن الوصف غير فارغ
		}
	}
}
