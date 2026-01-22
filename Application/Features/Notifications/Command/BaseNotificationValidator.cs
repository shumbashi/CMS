using Application.DTOs.NotificationDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Command
{
	public class BaseNotificationValidator : AbstractValidator<CreateNotificationDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseNotificationValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.SenderId)
				.NotEmpty().WithMessage(localizer["SenderIdRequired"]);

			RuleFor(x => x.NotificationType)
				.NotEmpty().WithMessage(localizer["NotificationTypeRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.NotificationTitle)
				.NotEmpty().WithMessage(localizer["NotificationTitleRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.SendDate)
				.NotEmpty().WithMessage(localizer["SendDateRequired"]);

			RuleFor(x => x.Content)
				.NotEmpty().WithMessage(localizer["ContentRequired"])
				.MaximumLength(500).WithMessage(localizer["MaxLengthIs500"]);
		}
	}
}
