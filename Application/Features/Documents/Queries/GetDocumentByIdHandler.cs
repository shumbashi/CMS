using Application.DTOs.DocumentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Queries
{
	public class GetDocumentByIdQuery : IRequest<ApiResponse<DocumentDto>>
	{
		public Guid Id { get; set; }
	}
	public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, ApiResponse<DocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetDocumentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<DocumentDto>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
		{
			var document = await _unitOfWork.DocumentRepository.GetByIdAsync(request.Id);
			if (document == null)
				return ApiResponse<DocumentDto>.Fail("الوثيقة غير موجودة.");

			var documentDto = _mapper.Map<DocumentDto>(document);
			return ApiResponse<DocumentDto>.Ok(documentDto, "تم جلب الوثيقة بنجاح.");
		}
	}
}
