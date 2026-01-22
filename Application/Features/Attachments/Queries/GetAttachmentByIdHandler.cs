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
	public class GetAttachmentByIdQuery : IRequest<ApiResponse<AttachmentDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetAttachmentByIdHandler : IRequestHandler<GetAttachmentByIdQuery, ApiResponse<AttachmentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAttachmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<AttachmentDto>> Handle(GetAttachmentByIdQuery request, CancellationToken cancellationToken)
		{
			var attachment = await _unitOfWork.AttachmentRepository.GetByIdAsync(request.Id);
			if (attachment == null)
			{
				return ApiResponse<AttachmentDto>.Fail("المرفق غير موجود.");
			}

			var attachmentDto = _mapper.Map<AttachmentDto>(attachment);
			return ApiResponse<AttachmentDto>.Ok(attachmentDto);
		}
	}
}
