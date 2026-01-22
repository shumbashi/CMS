using Application.DTOs.CompanyDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Company.Command
{
	public class BaseCompanyValidator : AbstractValidator<CreateCompanyDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseCompanyValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.CompanyName)
				.NotEmpty().WithMessage(localizer["CompanyNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.CommercialRecord)
				.NotEmpty().WithMessage(localizer["CommercialRecordRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);
		}
	}
}
