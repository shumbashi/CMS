using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Role.Command
{
	public class DeleteRoleCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleRepository _roleRepository;

		public DeleteRoleHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = _unitOfWork.RoleRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _roleRepository.GetByIdAsync(request.Id);
			if (role == null)
			{
				return ApiResponse<string>.Fail("الدور غير موجود.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			role.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة الدور إلى محذوف.");
		}
	}
}
