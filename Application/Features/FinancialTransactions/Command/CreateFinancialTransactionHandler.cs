using Application.DTOs.FinancialTransactionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Command
{
	public class CreateFinancialTransactionCommand : IRequest<ApiResponse<FinancialTransactionDto>>
	{
		public CreateFinancialTransactionDto CreateFinancialTransactionDTO { get; set; }
	}

	public class CreateFinancialTransactionHandler : IRequestHandler<CreateFinancialTransactionCommand, ApiResponse<FinancialTransactionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFinancialTransactionRepository _financialTransactionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateFinancialTransactionDto> _validator;

		public CreateFinancialTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateFinancialTransactionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_financialTransactionRepository = unitOfWork.FinancialTransactionRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<FinancialTransactionDto>> Handle(CreateFinancialTransactionCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateFinancialTransactionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<FinancialTransactionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var financialTransaction = _mapper.Map<FinancialTransaction>(request.CreateFinancialTransactionDTO);
			await _financialTransactionRepository.AddAsync(financialTransaction);
			await _unitOfWork.Commit();

			var financialTransactionDto = _mapper.Map<FinancialTransactionDto>(financialTransaction);
			return ApiResponse<FinancialTransactionDto>.Ok(financialTransactionDto, "تم إنشاء العملية المالية بنجاح.");
		}
	}
}
