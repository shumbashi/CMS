using Application.DTOs.ContractPartyDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace Application.Features.ContractParties.Command
{
	public class UpdateContractPartyValidator : AbstractValidator<UpdateContractPartyDto>
	{
		public UpdateContractPartyValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x).NotNull().WithMessage(localizer["RequestCannotBeNull"]);

			// Id must be present to locate the entity
			RuleFor(x => x.Id).NotEmpty().WithMessage(localizer["IdRequired"]);

			// Validate optional fields only when provided (patch-friendly)
			When(x => x.ContractPartyName != null, () =>
			{
				RuleFor(x => x.ContractPartyName)
					.NotEmpty().WithMessage(localizer["PartyNameRequired"])
					.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);
			});

			When(x => x.Residence != null, () =>
			{
				RuleFor(x => x.Residence)
					.NotEmpty().WithMessage(localizer["ResidenceRequired"])
					.MaximumLength(200).WithMessage(localizer["MaxLengthIs200"]);
			});

			When(x => x.DocumentIds != null, () =>
			{
				RuleForEach(x => x.DocumentIds)
					.NotEmpty().WithMessage(localizer["DocumentIdRequired"]);
			});

			When(x => x.CompanyIds != null, () =>
			{
				RuleForEach(x => x.CompanyIds)
					.NotEmpty().WithMessage(localizer["CompanyIdRequired"]);
			});
		}
	}
}
