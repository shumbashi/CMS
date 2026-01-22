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
	public class GetAllUserActivitiesQuery : IRequest<ApiResponse<IEnumerable<UserActivityDto>>>
	{
	}

	public class GetAllUserActivitiesHandler : IRequestHandler<GetAllUserActivitiesQuery, ApiResponse<IEnumerable<UserActivityDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserActivityRepository _userActivityRepository;
		private readonly IMapper _mapper;

		public GetAllUserActivitiesHandler(IUnitOfWork unitOfWork, IUserActivityRepository userActivityRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userActivityRepository = _unitOfWork.UserActivityRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<UserActivityDto>>> Handle(GetAllUserActivitiesQuery request, CancellationToken cancellationToken)
		{
			var userActivities = await _userActivityRepository.GetAllAsync();
			if (userActivities == null || !userActivities.Any())
			{
				return ApiResponse<IEnumerable<UserActivityDto>>.Fail("لا توجد أنشطة.");
			}

			var userActivityDtos = _mapper.Map<IEnumerable<UserActivityDto>>(userActivities);
			return ApiResponse<IEnumerable<UserActivityDto>>.Ok(userActivityDtos);
		}
	}
}
