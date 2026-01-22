using Application.DTOs.FinancialTransactionDTO;
using Application.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Command
{
	public class BaseFinancialTransactionValidator : AbstractValidator<CreateFinancialTransactionDto>  // قاعدة مشتركة بين Create و Update
	{
		public BaseFinancialTransactionValidator(IStringLocalizer<SharedResources> localizer)
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(localizer["UserIdRequired"]);

			RuleFor(x => x.DocumentId)
				.NotEmpty().WithMessage(localizer["DocumentIdRequired"]);

			RuleFor(x => x.TransactionStatus)
				.NotEmpty().WithMessage(localizer["TransactionStatusRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.TransactionType)
				.NotEmpty().WithMessage(localizer["TransactionTypeRequired"])
				.MaximumLength(50).WithMessage(localizer["MaxLengthIs50"]);

			RuleFor(x => x.TransactionDate)
				.NotEmpty().WithMessage(localizer["TransactionDateRequired"]);

			RuleFor(x => x.Amount)
				.GreaterThan(0).WithMessage(localizer["AmountGreaterThanZero"]);
		}
	}
}
