using Application.DTOs.RolePermissionDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolePermissions.Command
{
	public class BaseRolePermissionValidator : AbstractValidator<CreateRolePermissionDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseRolePermissionValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.RoleId)
				.NotEmpty().WithMessage(localizer["RoleIdRequired"]);

			RuleFor(x => x.PermissionId)
				.NotEmpty().WithMessage(localizer["PermissionIdRequired"]);
		}
	}
}
