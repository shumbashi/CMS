using Application.DTOs.CompanyDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace Application.Features.Company.Command
{
	public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyDto>
	{
		public UpdateCompanyValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x).NotNull().WithMessage(localizer["RequestCannotBeNull"]);

			// Id must be present to find the entity
			RuleFor(x => x.Id).NotEmpty().WithMessage(localizer["IdRequired"]);

			// Validate optional fields only when provided (patch-friendly)
			When(x => x.CompanyName != null, () =>
			{
				RuleFor(x => x.CompanyName)
					.NotEmpty().WithMessage(localizer["CompanyNameRequired"])
					.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);
			});

			When(x => x.CommercialRecord != null, () =>
			{
				RuleFor(x => x.CommercialRecord)
					.NotEmpty().WithMessage(localizer["CommercialRecordRequired"])
					.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);
			});
		}
	}
}
