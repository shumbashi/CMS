using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.TemplateField.Command
{
	public class DeleteTemplateFieldCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
		public string FieldName { get; set; }
	}

	public class DeleteTemplateFieldHandler : IRequestHandler<DeleteTemplateFieldCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITemplateFieldRepository _templateFieldRepository;

		public DeleteTemplateFieldHandler(IUnitOfWork unitOfWork, ITemplateFieldRepository templateFieldRepository)
		{
			_unitOfWork = unitOfWork;
			_templateFieldRepository = unitOfWork.TemplateFieldRepository;
		}

		public async Task<ApiResponse<string>> Handle(DeleteTemplateFieldCommand request, CancellationToken cancellationToken)
		{
			var templateField = await _templateFieldRepository.GetByIdAsync(request.Id);
			if (templateField == null)
			{
				return ApiResponse<string>.Fail("حقل القالب غير موجود.");
			}

			_templateFieldRepository.Delete(templateField);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف حقل القالب بنجاح.");
		}
	}
}
