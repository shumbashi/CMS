using Application.DTOs.ContractPartyDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class BaseContractPartyValidator : AbstractValidator<CreateContractPartyDto> // قاعدة مشتركة بين Create و Update
	{
		public BaseContractPartyValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.ContractPartyName)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Residence)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(200).WithMessage(localizer["MaxLengthIs200"]);

			RuleFor(x => x.DocumentIds)
				.NotEmpty().WithMessage(localizer["DocumentsRequired"]);

			RuleFor(x => x.CompanyIds)
				.NotEmpty().WithMessage(localizer["CompaniesRequired"]);
		}
	}
}
