using Application.DTOs.ContractPartyDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class CreateContractPartyCommand : IRequest<ApiResponse<ContractPartyDto>>
	{
		public CreateContractPartyDto CreateContractPartyDTO { get; set; }
	}

	public class CreateContractPartyHandler : IRequestHandler<CreateContractPartyCommand, ApiResponse<ContractPartyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateContractPartyDto> _validator;

		public CreateContractPartyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateContractPartyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<ContractPartyDto>> Handle(CreateContractPartyCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.CreateContractPartyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<ContractPartyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var contractParty = _mapper.Map<ContractParty>(request.CreateContractPartyDTO);
			await _unitOfWork.ContractPartyRepository.AddAsync(contractParty);
			await _unitOfWork.Commit();

			var contractPartyDto = _mapper.Map<ContractPartyDto>(contractParty);
			return ApiResponse<ContractPartyDto>.Ok(contractPartyDto, "تم إنشاء الطرف بنجاح.");
		}
	}
}
