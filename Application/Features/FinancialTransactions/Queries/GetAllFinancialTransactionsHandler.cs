using Application.DTOs.FinancialTransactionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Queries
{
	public class GetAllFinancialTransactionsQuery : IRequest<ApiResponse<IEnumerable<FinancialTransactionDto>>>
	{
	}

	public class GetAllFinancialTransactionsHandler : IRequestHandler<GetAllFinancialTransactionsQuery, ApiResponse<IEnumerable<FinancialTransactionDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFinancialTransactionRepository _financialTransactionRepository;
		private readonly IMapper _mapper;

		public GetAllFinancialTransactionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_financialTransactionRepository = unitOfWork.FinancialTransactionRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<FinancialTransactionDto>>> Handle(GetAllFinancialTransactionsQuery request, CancellationToken cancellationToken)
		{
			var financialTransactions = await _financialTransactionRepository.GetAllAsync();
			var financialTransactionDtos = _mapper.Map<IEnumerable<FinancialTransactionDto>>(financialTransactions);
			return ApiResponse<IEnumerable<FinancialTransactionDto>>.Ok(financialTransactionDtos);
		}
	}
}
