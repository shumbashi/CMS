using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AuditRecords.Command
{
	public class DeleteAuditRecordCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteAuditRecordHandler : IRequestHandler<DeleteAuditRecordCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAuditRecordRepository _auditRecordRepository;

		public DeleteAuditRecordHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_auditRecordRepository = unitOfWork.AuditRecordRepository;

		}

		public async Task<ApiResponse<string>> Handle(DeleteAuditRecordCommand request, CancellationToken cancellationToken)
		{
			var auditRecord = await _auditRecordRepository.GetByIdAsync(request.Id);
			if (auditRecord == null)
			{
				return ApiResponse<string>.Fail("سجل التدقيق غير موجود.");
			}

			_auditRecordRepository.Delete(auditRecord);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف سجل التدقيق بنجاح.");
		}
	}
}
