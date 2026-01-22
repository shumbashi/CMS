using Application.DTOs.PermissionDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Command
{
	public class BasePermissionValidator : AbstractValidator<CreatePermissionDto>  // قاعدة مشتركة بين Create و Update
	{
		public BasePermissionValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(localizer["PermissionNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Description)
				.MaximumLength(255).WithMessage(localizer["MaxLengthIs255"]);
		}
	}
}
