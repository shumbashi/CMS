using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class CreateTemplateValidator : BaseTemplateValidator
	{
		public CreateTemplateValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إذا كان هناك قواعد إضافية خاصة بـ Create يمكن إضافتها هنا
		}
	}
}
