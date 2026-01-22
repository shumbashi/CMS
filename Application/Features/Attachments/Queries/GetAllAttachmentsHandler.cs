using Application.DTOs.AttachmentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Attachments.Queries
{
	public class GetAllAttachmentsQuery : IRequest<ApiResponse<IEnumerable<AttachmentDto>>>
	{
	}

	public class GetAllAttachmentsHandler : IRequestHandler<GetAllAttachmentsQuery, ApiResponse<IEnumerable<AttachmentDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllAttachmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<AttachmentDto>>> Handle(GetAllAttachmentsQuery request, CancellationToken cancellationToken)
		{
			var attachments = await _unitOfWork.AttachmentRepository.GetAllAsync();
			var attachmentDtos = _mapper.Map<IEnumerable<AttachmentDto>>(attachments);
			return ApiResponse<IEnumerable<AttachmentDto>>.Ok(attachmentDtos);
		}
	}
}
