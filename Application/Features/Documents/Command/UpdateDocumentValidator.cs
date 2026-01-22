using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Command
{
	public class UpdateDocumentValidator : BaseDocumentValidator
	{
		public UpdateDocumentValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إذا كان هناك قواعد إضافية خاصة بـ Update يمكن إضافتها هنا
		}
	}
}
