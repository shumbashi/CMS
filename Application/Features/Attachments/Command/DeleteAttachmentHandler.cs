using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Attachments.Command
{
	public class DeleteAttachmentCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteAttachmentHandler : IRequestHandler<DeleteAttachmentCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAttachmentRepository _attachmentRepository;

		public DeleteAttachmentHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_attachmentRepository = unitOfWork.AttachmentRepository;
		}

		public async Task<ApiResponse<string>> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
		{
			var attachment = await _unitOfWork.AttachmentRepository.GetByIdAsync(request.Id);
			if (attachment == null)
			{
				return ApiResponse<string>.Fail("المرفق غير موجود.");
			}

			_attachmentRepository.Delete(attachment);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف المرفق بنجاح.");
		}
	}
}
