using Application.Helper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Command
{
	public class DeleteDocumentCommand : IRequest<ApiResponse<bool>>
	{
		public Guid Id { get; set; }
	}
	public class DeleteDocumentHandler : IRequestHandler<DeleteDocumentCommand, ApiResponse<bool>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteDocumentHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
		{
			var document = await _unitOfWork.DocumentRepository.GetByIdAsync(request.Id);
			if (document == null)
				return ApiResponse<bool>.Fail("الوثيقة غير موجودة.");

			_unitOfWork.DocumentRepository.Delete(document);
			await _unitOfWork.Commit();
			return ApiResponse<bool>.Ok(true, "تم حذف الوثيقة بنجاح.");
		}
	}
}
