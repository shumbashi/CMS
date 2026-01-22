using Application.DTOs.PersonsInCompanyDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PersonsInCompanies.Command
{
	public class BasePersonsInCompanyValidator : AbstractValidator<CreatePersonsInCompanyDto>  // قاعدة مشتركة بين Create و Update
	{
		public BasePersonsInCompanyValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.PersonName)
				.NotEmpty().WithMessage(localizer["PersonNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.CompanyId)
				.NotEmpty().WithMessage(localizer["CompanyIdRequired"]);

			RuleFor(x => x.ContractPartyId)
				.NotEmpty().WithMessage(localizer["ContractPartyIdRequired"]);

			RuleFor(x => x.PartyRoleId)
				.NotEmpty().WithMessage(localizer["PartyRoleIdRequired"]);

			RuleFor(x => x.IdentityId)
				.NotEmpty().WithMessage(localizer["IdentityIdRequired"]);
		}
	}
}
