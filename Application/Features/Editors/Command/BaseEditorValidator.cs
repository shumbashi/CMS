using Application.DTOs.EditorDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
	public class BaseEditorValidator : AbstractValidator<CreateEditorDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseEditorValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.InspectionNumber)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.SealNumber)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.DecisionNumber)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.CourtDivision)
				.NotEmpty().WithMessage(localizer["NotEmpty"])
				.MaximumLength(100).WithMessage(localizer["MaxLengthIs100"]);

			RuleFor(x => x.BirthDate)
				.NotEmpty().WithMessage(localizer["NotEmpty"]);

			RuleFor(x => x.FinancialBalance)
				.GreaterThanOrEqualTo(0).WithMessage(localizer["InvalidFinancialBalance"]);

		
		}
	}
}
