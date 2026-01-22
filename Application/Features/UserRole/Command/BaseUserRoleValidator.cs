using Application.DTOs.UserRoleDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserRole.Command
{
	public class BaseUserRoleValidator : AbstractValidator<CreateUserRoleDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseUserRoleValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(localizer["UserIdRequired"]);

			RuleFor(x => x.RoleId)
				.NotEmpty().WithMessage(localizer["RoleIdRequired"]);

			RuleFor(x => x.AssignedById)
				.NotEmpty().WithMessage(localizer["AssignedByIdRequired"]);
		}
	}
}
