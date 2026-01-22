using Application.DTOs.ContractPartyInDocumentDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractPartyInDocuments.Queries
{
	// Command لاسترجاع كل الـ ContractPartyInDocument
	public class GetAllContractPartyInDocumentsQuery : IRequest<ApiResponse<IEnumerable<ContractPartyInDocumentDto>>>
	{
	}

	// Handler لاسترجاع كل الـ ContractPartyInDocument
	public class GetAllContractPartyInDocumentsHandler : IRequestHandler<GetAllContractPartyInDocumentsQuery, ApiResponse<IEnumerable<ContractPartyInDocumentDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IContractPartyInDocumentRepository _contractPartyInDocumentRepository;
		private readonly IMapper _mapper;

		public GetAllContractPartyInDocumentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_contractPartyInDocumentRepository = _unitOfWork.ContractPartyInDocumentRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<ContractPartyInDocumentDto>>> Handle(GetAllContractPartyInDocumentsQuery request, CancellationToken cancellationToken)
		{
			var contractPartiesInDocument = await _contractPartyInDocumentRepository.GetAllAsync(); // استرجاع كل الـ ContractPartyInDocument
			if (contractPartiesInDocument == null || !contractPartiesInDocument.Any())
			{
				return ApiResponse<IEnumerable<ContractPartyInDocumentDto>>.Fail("لا توجد بيانات.");
			}

			var contractPartyInDocumentDtos = _mapper.Map<IEnumerable<ContractPartyInDocumentDto>>(contractPartiesInDocument); // تحويل البيانات إلى DTO
			return ApiResponse<IEnumerable<ContractPartyInDocumentDto>>.Ok(contractPartyInDocumentDtos); // إرجاع النتيجة بنجاح
		}
	}
}
