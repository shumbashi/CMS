using Application.DTOs.AttachmentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Attachments.Command
{
	public class CreateAttachmentCommand : IRequest<ApiResponse<AttachmentDto>>
	{
		public CreateAttachmentDto CreateAttachmentDTO { get; set; }
	}

	public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentCommand, ApiResponse<AttachmentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateAttachmentDto> _validator;

		public CreateAttachmentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateAttachmentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<AttachmentDto>> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateAttachmentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<AttachmentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var attachment = _mapper.Map<Attachment>(request.CreateAttachmentDTO);
			await _unitOfWork.AttachmentRepository.AddAsync(attachment);
			await _unitOfWork.Commit();

			var attachmentDto = _mapper.Map<AttachmentDto>(attachment);
			return ApiResponse<AttachmentDto>.Ok(attachmentDto, "تم إنشاء المرفق بنجاح.");
		}
	}
}
