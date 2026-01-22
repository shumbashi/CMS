using Application.DTOs.ContractPartyInDocumentDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractPartyInDocuments.Command
{
	public class BaseContractPartyInDocumentValidator : AbstractValidator<CreateContractPartyInDocumentDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseContractPartyInDocumentValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.ContractPartyName)
				.NotEmpty().WithMessage(localizer["ContractPartyNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.DocumentId)
				.NotEmpty().WithMessage(localizer["DocumentIdRequired"]);

			RuleFor(x => x.ContractPartyId)
				.NotEmpty().WithMessage(localizer["ContractPartyIdRequired"]);

			RuleFor(x => x.PartyRoleId)
				.NotEmpty().WithMessage(localizer["PartyRoleIdRequired"]);
		}
	}
}
