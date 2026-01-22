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
	public class GetAllDocumentsQuery : IRequest<ApiResponse<IEnumerable<DocumentDto>>>
	{
	}
	public class GetDocumentsHandler : IRequestHandler<GetAllDocumentsQuery, ApiResponse<IEnumerable<DocumentDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetDocumentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<DocumentDto>>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
		{
			var documents = await _unitOfWork.DocumentRepository.GetAllAsync();
			var documentDtos = _mapper.Map<IEnumerable<DocumentDto>>(documents);
			return ApiResponse<IEnumerable<DocumentDto>>.Ok(documentDtos, "تم جلب الوثائق بنجاح.");
		}
	}
}
