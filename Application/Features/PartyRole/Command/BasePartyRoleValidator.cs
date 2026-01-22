using Application.DTOs.PartyRoleDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PartyRole.Command
{
	public class BasePartyRoleValidator : AbstractValidator<CreatePartyRoleDto>  // قاعدة مشتركة بين Create و Update
	{
		public BasePartyRoleValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.RoleName)
				.NotEmpty().WithMessage(localizer["RoleNameRequired"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.RoleCode)
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);
		}
	}
}
