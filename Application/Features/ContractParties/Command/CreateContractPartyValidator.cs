using Application.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class CreateContractPartyValidator : BaseContractPartyValidator
	{
		public CreateContractPartyValidator(IStringLocalizer<SharedResources> localizer)
			: base(localizer)
		{
			// إذا كان هناك قواعد إضافية خاصة بـ Create يمكن إضافتها هنا
		}
	}
}
