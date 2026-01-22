using Application.DTOs.UserActivityDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserActivities.Command
{
	public class UpdateUserActivityCommand : IRequest<ApiResponse<UserActivityDto>>
	{
		public UpdateUserActivityDto UpdateUserActivityDTO { get; set; }
	}

	public class UpdateUserActivityHandler : IRequestHandler<UpdateUserActivityCommand, ApiResponse<UserActivityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserActivityRepository _userActivityRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateUserActivityDto> _validator;

		public UpdateUserActivityHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserActivityDto> validator)
		{
			_unitOfWork = unitOfWork;
			_userActivityRepository = _unitOfWork.UserActivityRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<UserActivityDto>> Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdateUserActivityDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<UserActivityDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب النشاط من الريبو
			var userActivity = await _userActivityRepository.GetByIdAsync(request.UpdateUserActivityDTO.Id);
			if (userActivity == null)
			{
				return ApiResponse<UserActivityDto>.Fail("النشاط غير موجود.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdateUserActivityDTO, userActivity);
			_userActivityRepository.Update(userActivity);
			await _unitOfWork.Commit();

			var userActivityDto = _mapper.Map<UserActivityDto>(userActivity);
			return ApiResponse<UserActivityDto>.Ok(userActivityDto, "تم تحديث النشاط بنجاح.");
		}
	}
}
