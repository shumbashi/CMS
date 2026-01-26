using Application.DTOs.UserRoleDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserRole.Command
{
	// Application/Validators/UserRole/UpdateUserRoleValidator.cs

	public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleDto>
	{
		public UpdateUserRoleValidator(IStringLocalizer<SharedResources> localizer)
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
