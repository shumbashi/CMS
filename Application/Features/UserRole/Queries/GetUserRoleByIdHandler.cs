using Application.DTOs.UserRoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserRole.Queries
{
	public class GetUserRoleByIdQuery : IRequest<ApiResponse<UserRoleDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, ApiResponse<UserRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRoleRepository _userRoleRepository;
		private readonly IMapper _mapper;

		public GetUserRoleByIdHandler(IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userRoleRepository = _unitOfWork.UserRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<UserRoleDto>> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var userRole = await _userRoleRepository.GetByIdAsync(request.Id);
			if (userRole == null)
			{
				return ApiResponse<UserRoleDto>.Fail("العلاقة غير موجودة.");
			}

			var userRoleDto = _mapper.Map<UserRoleDto>(userRole);
			return ApiResponse<UserRoleDto>.Ok(userRoleDto);
		}
	}

}
