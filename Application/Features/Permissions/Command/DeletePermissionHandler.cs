using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Command
{
	public class DeletePermissionCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeletePermissionHandler : IRequestHandler<DeletePermissionCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPermissionRepository _permissionRepository;

		public DeletePermissionHandler(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = _unitOfWork.PermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
		{
			var permission = await _permissionRepository.GetByIdAsync(request.Id);
			if (permission == null)
			{
				return ApiResponse<string>.Fail("الصلاحية غير موجودة.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			permission.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة الصلاحية إلى محذوفة.");
		}
	}
}
