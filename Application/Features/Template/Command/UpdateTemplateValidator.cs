using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class UpdateTemplateValidator : BaseTemplateValidator
	{
		public UpdateTemplateValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إذا كان هناك قواعد إضافية خاصة بـ Update يمكن إضافتها هنا
		}
	}
}
