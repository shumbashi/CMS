using Application.DTOs.NotificationDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Notifications.Command
{
	public class UpdateNotificationCommand : IRequest<ApiResponse<NotificationDto>>
	{
		public UpdateNotificationDto UpdateNotificationDTO { get; set; }
	}

	public class UpdateNotificationHandler : IRequestHandler<UpdateNotificationCommand, ApiResponse<NotificationDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly INotificationRepository _notificationRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateNotificationDto> _validator;

		public UpdateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateNotificationDto> validator)
		{
			_unitOfWork = unitOfWork;
			_notificationRepository = unitOfWork.NotificationRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<NotificationDto>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateNotificationDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<NotificationDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var notification = await _notificationRepository.GetByIdAsync(request.UpdateNotificationDTO.Id);
			if (notification == null)
			{
				return ApiResponse<NotificationDto>.Fail("التنبيه غير موجود.");
			}

			_mapper.Map(request.UpdateNotificationDTO, notification);
			_notificationRepository.Update(notification);
			await _unitOfWork.Commit();

			var notificationDto = _mapper.Map<NotificationDto>(notification);
			return ApiResponse<NotificationDto>.Ok(notificationDto, "تم تحديث التنبيه بنجاح.");
		}
	}
}
