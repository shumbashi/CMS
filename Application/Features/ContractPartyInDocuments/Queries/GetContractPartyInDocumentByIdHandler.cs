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
	// Command لاسترجاع الطرف في الوثيقة بواسطة ID
	public class GetContractPartyInDocumentByIdQuery : IRequest<ApiResponse<ContractPartyInDocumentDto>>
	{
		public Guid Id { get; set; }  // إضافة الـ Id الذي نبحث عنه
	}

	// Handler لاسترجاع الطرف في الوثيقة بواسطة ID
	public class GetContractPartyInDocumentByIdHandler : IRequestHandler<GetContractPartyInDocumentByIdQuery, ApiResponse<ContractPartyInDocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IContractPartyInDocumentRepository _contractPartyInDocumentRepository;
		private readonly IMapper _mapper;

		public GetContractPartyInDocumentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_contractPartyInDocumentRepository = _unitOfWork.ContractPartyInDocumentRepository;  // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		public async Task<ApiResponse<ContractPartyInDocumentDto>> Handle(GetContractPartyInDocumentByIdQuery request, CancellationToken cancellationToken)
		{
			// استخدام الـ ID للبحث في الريبو
			var contractPartyInDocument = await _contractPartyInDocumentRepository.GetByIdAsync(request.Id);

			// إذا لم يتم العثور على السجل
			if (contractPartyInDocument == null)
			{
				return ApiResponse<ContractPartyInDocumentDto>.Fail("الطرف في الوثيقة غير موجود.");
			}

			// تحويل الكيان إلى DTO
			var contractPartyInDocumentDto = _mapper.Map<ContractPartyInDocumentDto>(contractPartyInDocument);

			// إرجاع النتيجة بنجاح
			return ApiResponse<ContractPartyInDocumentDto>.Ok(contractPartyInDocumentDto);
		}
	}
}
