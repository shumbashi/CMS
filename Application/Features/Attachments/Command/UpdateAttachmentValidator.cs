using Application.DTOs.AttachmentDTO;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace Application.Features.Attachments.Command
{
	public class UpdateAttachmentValidator : AbstractValidator<UpdateAttachmentDto>
	{
		public UpdateAttachmentValidator(IStringLocalizer<UpdateAttachmentDto> localizer)
		{
			RuleFor(x => x).NotNull().WithMessage("Request cannot be null.");

			RuleFor(x => x).Custom((dto, ctx) =>
			{
				if (dto == null) return;

				var idProp = dto.GetType().GetProperty("Id");
				if (idProp != null && idProp.PropertyType == typeof(Guid))
				{
					var val = (Guid)idProp.GetValue(dto);
					if (val == Guid.Empty) ctx.AddFailure("Id", "Id is required.");
				}

				var nameProp = dto.GetType().GetProperty("AttachmentName") ?? dto.GetType().GetProperty("Name");
				if (nameProp != null && nameProp.PropertyType == typeof(string))
				{
					var s = (string)nameProp.GetValue(dto);
					if (string.IsNullOrWhiteSpace(s)) ctx.AddFailure(nameProp.Name, $"{nameProp.Name} is required.");
				}
			});
		}
	}
}
