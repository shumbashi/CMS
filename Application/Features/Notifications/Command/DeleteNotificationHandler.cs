using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Command
{
	public class DeleteNotificationCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly INotificationRepository _notificationRepository;

		public DeleteNotificationHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_notificationRepository = unitOfWork.NotificationRepository;
		}

		public async Task<ApiResponse<string>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
		{
			var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id);
			if (notification == null)
			{
				return ApiResponse<string>.Fail("التنبيه غير موجود.");
			}

			_notificationRepository.Delete(notification);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف التنبيه بنجاح.");
		}
	}
}
