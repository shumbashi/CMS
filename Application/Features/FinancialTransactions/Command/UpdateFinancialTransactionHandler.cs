using Application.DTOs.FinancialTransactionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.FinancialTransactions.Command
{
	public class UpdateFinancialTransactionCommand : IRequest<ApiResponse<FinancialTransactionDto>>
	{
		public UpdateFinancialTransactionDto UpdateFinancialTransactionDTO { get; set; }
	}

	public class UpdateFinancialTransactionHandler : IRequestHandler<UpdateFinancialTransactionCommand, ApiResponse<FinancialTransactionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFinancialTransactionRepository _financialTransactionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateFinancialTransactionDto> _validator;

		public UpdateFinancialTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateFinancialTransactionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_financialTransactionRepository = unitOfWork.FinancialTransactionRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<FinancialTransactionDto>> Handle(UpdateFinancialTransactionCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateFinancialTransactionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<FinancialTransactionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var financialTransaction = await _financialTransactionRepository.GetByIdAsync(request.UpdateFinancialTransactionDTO.Id);
			if (financialTransaction == null)
			{
				return ApiResponse<FinancialTransactionDto>.Fail("العملية المالية غير موجودة.");
			}

			_mapper.Map(request.UpdateFinancialTransactionDTO, financialTransaction);
			_financialTransactionRepository.Update(financialTransaction);
			await _unitOfWork.Commit();

			var financialTransactionDto = _mapper.Map<FinancialTransactionDto>(financialTransaction);
			return ApiResponse<FinancialTransactionDto>.Ok(financialTransactionDto, "تم تحديث العملية المالية بنجاح.");
		}
	}
}
