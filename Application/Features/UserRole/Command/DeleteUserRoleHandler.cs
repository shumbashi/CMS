using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserRole.Command
{
	public class DeleteUserRoleCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRoleRepository _userRoleRepository;

		public DeleteUserRoleHandler(IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository)
		{
			_unitOfWork = unitOfWork;
			_userRoleRepository = _unitOfWork.UserRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
		{
			var userRole = await _userRoleRepository.GetByIdAsync(request.Id);
			if (userRole == null)
			{
				return ApiResponse<string>.Fail("العلاقة غير موجودة.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			userRole.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة العلاقة إلى محذوف.");
		}
	}
}
