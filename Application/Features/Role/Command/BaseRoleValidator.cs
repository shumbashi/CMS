using Application.DTOs.RoleDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Role.Command
{
	public class BaseRoleValidator : AbstractValidator<CreateRoleDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseRoleValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage(localizer["RoleNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.Description)
				.MaximumLength(500).WithMessage(localizer["MaxLengthIs500"]);
		}
	}
}
