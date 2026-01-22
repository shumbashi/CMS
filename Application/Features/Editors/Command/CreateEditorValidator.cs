using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
		public class CreateEditorValidator : BaseEditorValidator
		{
			public CreateEditorValidator(IStringLocalizer<SharedResources> localizer)
				: base(localizer)
			{
				// إضافة القواعد الخاصة بـ Create فقط إذا كانت مختلفة عن القاعدة المشتركة
				
			}
		}
	}
