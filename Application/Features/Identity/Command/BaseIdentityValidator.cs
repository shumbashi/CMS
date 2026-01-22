using Application.DTOs.IdentityDTO;
using Application.Resources;
using Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.Command
{
	public class BaseIdentityValidator : AbstractValidator<CreateIdentityDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseIdentityValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.IdentityType)
				.NotEmpty().WithMessage(localizer["IdentityTypeRequired"]);

			RuleFor(x => x.Nationality)
				.NotEmpty().WithMessage(localizer["NationalityRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.PhoneNumber)
				.NotEmpty().WithMessage(localizer["PhoneNumberRequired"])
				.MaximumLength(15).WithMessage(localizer["MaxLengthIs15"]);

			RuleFor(x => x.IdentityProof)
				.NotEmpty().WithMessage(localizer["IdentityProofRequired"]);

			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(localizer["UserIdRequired"]);

			RuleFor(x => x.BirthDate)
				.NotEmpty().WithMessage(localizer["BirthDateRequired"]);

			RuleFor(x => x)
				   .Custom((x, context) =>
				   {
					   if (x.IdentityType == IdentityType.Citizen)
					   {
						   if (string.IsNullOrWhiteSpace(x.NationalNumber) && string.IsNullOrWhiteSpace(x.AdministrativeNumber))
						   {
							   context.AddFailure("المواطن لازم يكون عنده رقم وطني أو رقم إداري");
						   }

						   if (!string.IsNullOrWhiteSpace(x.ResidenceNumber))
						   {
							   context.AddFailure("المواطن ما يكونش عنده رقم إقامة");
						   }
					   }

					   if (x.IdentityType == IdentityType.Resident)
					   {
						   if (string.IsNullOrWhiteSpace(x.ResidenceNumber))
						   {
							   context.AddFailure("المقيم لازم يكون عنده رقم إقامة");
						   }

						   if (!string.IsNullOrWhiteSpace(x.NationalNumber) || !string.IsNullOrWhiteSpace(x.AdministrativeNumber))
						   {
							   context.AddFailure("المقيم ما يكونش عنده رقم وطني أو إداري");
						   }
					   }
				   });
		}
	}
}
