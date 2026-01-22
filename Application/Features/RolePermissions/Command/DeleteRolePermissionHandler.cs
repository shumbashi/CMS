using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolePermissions.Command
{
	public class DeleteRolePermissionCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteRolePermissionHandler : IRequestHandler<DeleteRolePermissionCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRolePermissionRepository _rolePermissionRepository;

		public DeleteRolePermissionHandler(IUnitOfWork unitOfWork, IRolePermissionRepository rolePermissionRepository)
		{
			_unitOfWork = unitOfWork;
			_rolePermissionRepository = _unitOfWork.RolePermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeleteRolePermissionCommand request, CancellationToken cancellationToken)
		{
			var rolePermission = await _rolePermissionRepository.GetByIdAsync(request.Id);
			if (rolePermission == null)
			{
				return ApiResponse<string>.Fail("العلاقة بين الدور والصلاحية غير موجودة.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			rolePermission.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة العلاقة إلى محذوفة.");
		}
	}

}
