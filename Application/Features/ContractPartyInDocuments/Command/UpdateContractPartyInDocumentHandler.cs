using Application.DTOs.ContractPartyInDocumentDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractPartyInDocuments.Command
{
	public class UpdateContractPartyInDocumentCommand : IRequest<ApiResponse<ContractPartyInDocumentDto>>
	{
		public UpdateContractPartyInDocumentDto UpdateContractPartyInDocumentDTO { get; set; }
	}

	public class UpdateContractPartyInDocumentHandler : IRequestHandler<UpdateContractPartyInDocumentCommand, ApiResponse<ContractPartyInDocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IContractPartyInDocumentRepository _contractPartyInDocumentRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateContractPartyInDocumentDto> _validator;

		public UpdateContractPartyInDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateContractPartyInDocumentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_contractPartyInDocumentRepository = unitOfWork.ContractPartyInDocumentRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<ContractPartyInDocumentDto>> Handle(UpdateContractPartyInDocumentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateContractPartyInDocumentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<ContractPartyInDocumentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var contractPartyInDocument = await _contractPartyInDocumentRepository.GetByIdAsync(request.UpdateContractPartyInDocumentDTO.Id);
			if (contractPartyInDocument == null)
			{
				return ApiResponse<ContractPartyInDocumentDto>.Fail("الطرف في الوثيقة غير موجود.");
			}

			_mapper.Map(request.UpdateContractPartyInDocumentDTO, contractPartyInDocument);
			_contractPartyInDocumentRepository.Update(contractPartyInDocument);
			await _unitOfWork.Commit();

			var contractPartyInDocumentDto = _mapper.Map<ContractPartyInDocumentDto>(contractPartyInDocument);
			return ApiResponse<ContractPartyInDocumentDto>.Ok(contractPartyInDocumentDto, "تم تحديث الطرف في الوثيقة بنجاح.");
		}
	}
}
