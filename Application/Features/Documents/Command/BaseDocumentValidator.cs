using Application.DTOs.DocumentDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Command
{
	public class BaseDocumentValidator : AbstractValidator<CreateDocumentDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseDocumentValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.Code)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.IssueDate)
				.NotEmpty().WithMessage(localizer["NotEmpty"]);

			RuleFor(x => x.DocumentStatus)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.Notes)
				.MaximumLength(200).WithMessage(localizer["MaxLengthIs200"]);

			RuleFor(x => x.AuthenticationNumber)
				.GreaterThanOrEqualTo(1).WithMessage(localizer["InvalidAuthenticationNumber"]);

			RuleFor(x => x.Clause)
				.NotEmpty().WithMessage(localizer["NotEmpty"]);

			RuleFor(x => x.TemplateId)
				.NotEmpty().WithMessage(localizer["TemplateIdRequired"]);

			RuleFor(x => x.EditorId)
				.NotEmpty().WithMessage(localizer["EditorIdRequired"]);

			RuleFor(x => x.ContractPartyIds)
				.NotEmpty().WithMessage(localizer["ContractPartiesRequired"]);

			RuleFor(x => x.AttachmentIds)
				.NotEmpty().WithMessage(localizer["AttachmentsRequired"]);
		}
	}
}
