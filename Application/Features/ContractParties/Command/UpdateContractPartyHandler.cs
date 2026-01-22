using Application.DTOs.ContractPartyDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class UpdateContractPartyCommand : IRequest<ApiResponse<ContractPartyDto>>
	{
		public UpdateContractPartyDto UpdateContractPartyDTO { get; set; }
	}

	public class UpdateContractPartyHandler : IRequestHandler<UpdateContractPartyCommand, ApiResponse<ContractPartyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateContractPartyDto> _validator;

		public UpdateContractPartyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateContractPartyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<ContractPartyDto>> Handle(UpdateContractPartyCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.UpdateContractPartyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<ContractPartyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var contractParty = await _unitOfWork.ContractPartyRepository.GetByIdAsync(request.UpdateContractPartyDTO.Id);
			if (contractParty == null)
				return ApiResponse<ContractPartyDto>.Fail("الطرف غير موجود.");

			_mapper.Map(request.UpdateContractPartyDTO, contractParty);
			await _unitOfWork.Commit();

			var contractPartyDto = _mapper.Map<ContractPartyDto>(contractParty);
			return ApiResponse<ContractPartyDto>.Ok(contractPartyDto, "تم تعديل الطرف بنجاح.");
		}
	}
}
