using Application.DTOs.NotificationDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Queries
{
	public class GetAllNotificationsQuery : IRequest<ApiResponse<IEnumerable<NotificationDto>>>
	{
	}

	public class GetAllNotificationsHandler : IRequestHandler<GetAllNotificationsQuery, ApiResponse<IEnumerable<NotificationDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly INotificationRepository _notificationRepository;
		private readonly IMapper _mapper;

		public GetAllNotificationsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_notificationRepository = unitOfWork.NotificationRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<NotificationDto>>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
		{
			var notifications = await _notificationRepository.GetAllAsync();
			var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(notifications);
			return ApiResponse<IEnumerable<NotificationDto>>.Ok(notificationDtos);
		}
	}

}
