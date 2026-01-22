using Application.DTOs.ContractPartyInDocumentDTO;
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

namespace Application.Features.ContractPartyInDocuments.Command
{
	public class CreateContractPartyInDocumentCommand : IRequest<ApiResponse<ContractPartyInDocumentDto>>
	{
		public CreateContractPartyInDocumentDto CreateContractPartyInDocumentDTO { get; set; }
	}

	public class CreateContractPartyInDocumentHandler : IRequestHandler<CreateContractPartyInDocumentCommand, ApiResponse<ContractPartyInDocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IContractPartyInDocumentRepository _contractPartyInDocumentRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateContractPartyInDocumentDto> _validator;

		public CreateContractPartyInDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateContractPartyInDocumentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_contractPartyInDocumentRepository = unitOfWork.ContractPartyInDocumentRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<ContractPartyInDocumentDto>> Handle(CreateContractPartyInDocumentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateContractPartyInDocumentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<ContractPartyInDocumentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var contractPartyInDocument = _mapper.Map<ContractPartyInDocument>(request.CreateContractPartyInDocumentDTO);
			await _contractPartyInDocumentRepository.AddAsync(contractPartyInDocument);
			await _unitOfWork.Commit();

			var contractPartyInDocumentDto = _mapper.Map<ContractPartyInDocumentDto>(contractPartyInDocument);
			return ApiResponse<ContractPartyInDocumentDto>.Ok(contractPartyInDocumentDto, "تم إنشاء الطرف في الوثيقة بنجاح.");
		}
	}
}
