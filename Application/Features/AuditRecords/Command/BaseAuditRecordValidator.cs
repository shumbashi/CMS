using Application.DTOs.AuditRecordDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AuditRecords.Command
{
	public class BaseAuditRecordValidator : AbstractValidator<CreateAuditRecordDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseAuditRecordValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(localizer["UserIdRequired"]);

			RuleFor(x => x.ActionType)
				.NotEmpty().WithMessage(localizer["ActionTypeRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.ActionDate)
				.NotEmpty().WithMessage(localizer["ActionDateRequired"]);

			RuleFor(x => x.IpAddress)
				.NotEmpty().WithMessage(localizer["IpAddressRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.AffectedEntityName)
				.NotEmpty().WithMessage(localizer["AffectedEntityNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.AffectedEntityId)
				.NotEmpty().WithMessage(localizer["AffectedEntityIdRequired"]);

			RuleFor(x => x.ChangeDetails)
				.MaximumLength(500).WithMessage(localizer["MaxLengthIs500"]);
		}
	}
}
