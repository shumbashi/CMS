using Application.DTOs.AttachmentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Attachments.Command
{
	public class UpdateAttachmentCommand : IRequest<ApiResponse<AttachmentDto>>
	{
		public UpdateAttachmentDto UpdateAttachmentDTO { get; set; }
	}

	public class UpdateAttachmentHandler : IRequestHandler<UpdateAttachmentCommand, ApiResponse<AttachmentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateAttachmentDto> _validator;

		public UpdateAttachmentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateAttachmentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<AttachmentDto>> Handle(UpdateAttachmentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateAttachmentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<AttachmentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var attachment = await _unitOfWork.AttachmentRepository.GetByIdAsync(request.UpdateAttachmentDTO.Id);
			if (attachment == null)
			{
				return ApiResponse<AttachmentDto>.Fail("المرفق غير موجود.");
			}

			_mapper.Map(request.UpdateAttachmentDTO, attachment);
			_unitOfWork.AttachmentRepository.Update(attachment);
			await _unitOfWork.Commit();

			var attachmentDto = _mapper.Map<AttachmentDto>(attachment);
			return ApiResponse<AttachmentDto>.Ok(attachmentDto, "تم تحديث المرفق بنجاح.");
		}
	}
}
