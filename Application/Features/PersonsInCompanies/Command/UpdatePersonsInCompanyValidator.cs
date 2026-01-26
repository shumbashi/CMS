using Application.DTOs.PersonsInCompanyDTO;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace Application.Features.PersonsInCompanies.Command
{
	public class UpdatePersonsInCompanyValidator : AbstractValidator<UpdatePersonsInCompanyDto>
	{
		public UpdatePersonsInCompanyValidator(IStringLocalizer<UpdatePersonsInCompanyDto> localizer)
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
			});
		}
	}
}
