using Application.DTOs.NotificationDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Command
{
	public class CreateNotificationCommand : IRequest<ApiResponse<NotificationDto>>
	{
		public CreateNotificationDto CreateNotificationDTO { get; set; }
	}

	public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, ApiResponse<NotificationDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly INotificationRepository _notificationRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateNotificationDto> _validator;

		public CreateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateNotificationDto> validator)
		{
			_unitOfWork = unitOfWork;
			_notificationRepository = unitOfWork.NotificationRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<NotificationDto>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateNotificationDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<NotificationDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var notification = _mapper.Map<Notification>(request.CreateNotificationDTO);
			await _notificationRepository.AddAsync(notification);
			await _unitOfWork.Commit();

			var notificationDto = _mapper.Map<NotificationDto>(notification);
			return ApiResponse<NotificationDto>.Ok(notificationDto, "تم إنشاء التنبيه بنجاح.");
		}
	}
}
