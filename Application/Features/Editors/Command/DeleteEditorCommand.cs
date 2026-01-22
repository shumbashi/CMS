using Application.Helper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
	public class DeleteEditorCommand : IRequest<ApiResponse<bool>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteEditorHandler : IRequestHandler<DeleteEditorCommand, ApiResponse<bool>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteEditorHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(DeleteEditorCommand request, CancellationToken cancellationToken)
		{
			var editor = await _unitOfWork.EditorRepository.GetByIdAsync(request.Id);
			if (editor == null)
				return ApiResponse<bool>.Fail("المحرر غير موجود.");

			_unitOfWork.EditorRepository.Delete(editor);
			await _unitOfWork.Commit();
			return ApiResponse<bool>.Ok(true, "تم حذف المحرر بنجاح.");
		}
	}
}
