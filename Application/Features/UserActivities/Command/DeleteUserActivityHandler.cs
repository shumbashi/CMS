using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserActivities.Command
{
	public class DeleteUserActivityCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteUserActivityHandler : IRequestHandler<DeleteUserActivityCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserActivityRepository _userActivityRepository;

		public DeleteUserActivityHandler(IUnitOfWork unitOfWork, IUserActivityRepository userActivityRepository)
		{
			_unitOfWork = unitOfWork;
			_userActivityRepository = _unitOfWork.UserActivityRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeleteUserActivityCommand request, CancellationToken cancellationToken)
		{
			var userActivity = await _userActivityRepository.GetByIdAsync(request.Id);
			if (userActivity == null)
			{
				return ApiResponse<string>.Fail("النشاط غير موجود.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			userActivity.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة النشاط إلى محذوف.");
		}
	}
}
