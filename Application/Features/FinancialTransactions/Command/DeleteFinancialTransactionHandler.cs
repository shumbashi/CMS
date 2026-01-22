using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Command
{
	public class DeleteFinancialTransactionCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteFinancialTransactionHandler : IRequestHandler<DeleteFinancialTransactionCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFinancialTransactionRepository _financialTransactionRepository;

		public DeleteFinancialTransactionHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_financialTransactionRepository = unitOfWork.FinancialTransactionRepository;
		}

		public async Task<ApiResponse<string>> Handle(DeleteFinancialTransactionCommand request, CancellationToken cancellationToken)
		{
			var financialTransaction = await _unitOfWork.FinancialTransactionRepository.GetByIdAsync(request.Id);
			if (financialTransaction == null)
			{
				return ApiResponse<string>.Fail("العملية المالية غير موجودة.");
			}

			_financialTransactionRepository.Delete(financialTransaction);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف العملية المالية بنجاح.");
		}
	}
}
