using Application.Helper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class DeleteTemplateCommand : IRequest<ApiResponse<bool>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteTemplateHandler : IRequestHandler<DeleteTemplateCommand, ApiResponse<bool>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteTemplateHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
		{
			var template = await _unitOfWork.TemplateRepository.GetByIdAsync(request.Id);
			if (template == null)
				return ApiResponse<bool>.Fail("القالب غير موجود.");

			_unitOfWork.TemplateRepository.Delete(template);
			await _unitOfWork.Commit();
			return ApiResponse<bool>.Ok(true, "تم حذف القالب بنجاح.");
		}
	}
}
