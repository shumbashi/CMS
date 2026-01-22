using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
	public class UpdateEditorValidator : BaseEditorValidator
	{
		public UpdateEditorValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إضافة القواعد الخاصة بـ Update فقط إذا كانت مختلفة عن القاعدة المشتركة
			RuleFor(x => x.SealNumber)
				.MaximumLength(100).WithMessage(localizer["MaxLengthForSealNumberUpdate"]);
		}
	}
}
