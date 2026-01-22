using Application.DTOs.UserActivityDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserActivities.Queries
{
	public class GetUserActivityByIdQuery : IRequest<ApiResponse<UserActivityDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetUserActivityByIdHandler : IRequestHandler<GetUserActivityByIdQuery, ApiResponse<UserActivityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserActivityRepository _userActivityRepository;
		private readonly IMapper _mapper;

		public GetUserActivityByIdHandler(IUnitOfWork unitOfWork, IUserActivityRepository userActivityRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userActivityRepository = _unitOfWork.UserActivityRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<UserActivityDto>> Handle(GetUserActivityByIdQuery request, CancellationToken cancellationToken)
		{
			var userActivity = await _userActivityRepository.GetByIdAsync(request.Id);
			if (userActivity == null)
			{
				return ApiResponse<UserActivityDto>.Fail("النشاط غير موجود.");
			}

			var userActivityDto = _mapper.Map<UserActivityDto>(userActivity);
			return ApiResponse<UserActivityDto>.Ok(userActivityDto);
		}
	}
}
