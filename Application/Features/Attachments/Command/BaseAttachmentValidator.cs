using Application.DTOs.AttachmentDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Attachments.Command
{
	public class BaseAttachmentValidator : AbstractValidator<CreateAttachmentDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseAttachmentValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.DocumentId)
				.NotEmpty().WithMessage(localizer["DocumentIdRequired"]);

			RuleFor(x => x.AttachmentType)
				.NotEmpty().WithMessage(localizer["AttachmentTypeRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.StoragePath)
				.NotEmpty().WithMessage(localizer["StoragePathRequired"])
				.MaximumLength(255).WithMessage(localizer["MaxLengthIs255"]);

			RuleFor(x => x.FileSize)
				.GreaterThan(0).WithMessage(localizer["FileSizeGreaterThanZero"]);
		}
	}
}
