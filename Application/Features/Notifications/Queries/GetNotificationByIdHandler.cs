using Application.DTOs.NotificationDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Queries
{
	public class GetNotificationByIdQuery : IRequest<ApiResponse<NotificationDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetNotificationByIdHandler : IRequestHandler<GetNotificationByIdQuery, ApiResponse<NotificationDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetNotificationByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<NotificationDto>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
		{
			var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id);
			if (notification == null)
			{
				return ApiResponse<NotificationDto>.Fail("التنبيه غير موجود.");
			}

			var notificationDto = _mapper.Map<NotificationDto>(notification);
			return ApiResponse<NotificationDto>.Ok(notificationDto);
		}
	}
	
}
