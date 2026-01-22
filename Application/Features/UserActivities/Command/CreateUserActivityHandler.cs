using Application.DTOs.UserActivityDTO;
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

namespace Application.Features.UserActivities.Command
{
	public class CreateUserActivityCommand : IRequest<ApiResponse<UserActivityDto>>
	{
		public CreateUserActivityDto CreateUserActivityDTO { get; set; }
	}

	public class CreateUserActivityHandler : IRequestHandler<CreateUserActivityCommand, ApiResponse<UserActivityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserActivityRepository _userActivityRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateUserActivityDto> _validator;

		public CreateUserActivityHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserActivityDto> validator)
		{
			_unitOfWork = unitOfWork;
			_userActivityRepository = _unitOfWork.UserActivityRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<UserActivityDto>> Handle(CreateUserActivityCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreateUserActivityDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<UserActivityDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var userActivity = _mapper.Map<UserActivity>(request.CreateUserActivityDTO);
			await _userActivityRepository.AddAsync(userActivity);
			await _unitOfWork.Commit();

			var userActivityDto = _mapper.Map<UserActivityDto>(userActivity);
			return ApiResponse<UserActivityDto>.Ok(userActivityDto, "تم إنشاء النشاط بنجاح.");
		}
	}
}
