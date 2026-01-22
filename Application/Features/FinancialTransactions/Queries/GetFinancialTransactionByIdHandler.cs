using Application.DTOs.FinancialTransactionDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Queries
{
	public class GetFinancialTransactionByIdQuery : IRequest<ApiResponse<FinancialTransactionDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetFinancialTransactionByIdHandler : IRequestHandler<GetFinancialTransactionByIdQuery, ApiResponse<FinancialTransactionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetFinancialTransactionByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<FinancialTransactionDto>> Handle(GetFinancialTransactionByIdQuery request, CancellationToken cancellationToken)
		{
			var financialTransaction = await _unitOfWork.FinancialTransactionRepository.GetByIdAsync(request.Id);
			if (financialTransaction == null)
			{
				return ApiResponse<FinancialTransactionDto>.Fail("العملية المالية غير موجودة.");
			}

			var financialTransactionDto = _mapper.Map<FinancialTransactionDto>(financialTransaction);
			return ApiResponse<FinancialTransactionDto>.Ok(financialTransactionDto);
		}
	}
}
