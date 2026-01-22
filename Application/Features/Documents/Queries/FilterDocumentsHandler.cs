using Application.DTOs.DocumentDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Queries
{
	public class FilterDocumentQuery : IRequest<ApiResponse<IEnumerable<DocumentDto>>>
	{
		public FilterDocumentDto FilterDto { get; set; }
	}
	public class FilterDocumentHandler : IRequestHandler<FilterDocumentQuery, ApiResponse<IEnumerable<DocumentDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IDocumentRepository _documentRepository;
		private readonly IMapper _mapper;

		public FilterDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_documentRepository = unitOfWork.DocumentRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<DocumentDto>>> Handle(FilterDocumentQuery request, CancellationToken cancellationToken)
		{
			var documentQeury = await _documentRepository.FilterDocumentsAsync(request.FilterDto);

			// تحويل النتائج إلى DTO
			var documentDtos = _mapper.Map<IEnumerable<DocumentDto>>(documentQeury);

			// إرجاع النتيجة
			return ApiResponse<IEnumerable<DocumentDto>>.Ok(documentDtos, "تم تطبيق الفلترة بنجاح.");
		}
	}
}
