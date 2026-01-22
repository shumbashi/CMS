using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class UpdateContractPartyValidator : BaseContractPartyValidator
	{
		public UpdateContractPartyValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إذا كان هناك قواعد إضافية خاصة بـ Update يمكن إضافتها هنا
		}
	}
}
