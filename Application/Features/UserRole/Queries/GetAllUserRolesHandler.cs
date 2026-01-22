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
	public class GetAllUserRolesQuery : IRequest<ApiResponse<IEnumerable<UserRoleDto>>>
	{
	}

	public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesQuery, ApiResponse<IEnumerable<UserRoleDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRoleRepository _userRoleRepository;
		private readonly IMapper _mapper;

		public GetAllUserRolesHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userRoleRepository = unitOfWork.UserRoleRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<UserRoleDto>>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
		{
			var userRoles = await _userRoleRepository.GetAllAsync();
			if (userRoles == null || !userRoles.Any())
			{
				return ApiResponse<IEnumerable<UserRoleDto>>.Fail("لا توجد أدوار.");
			}

			var userRoleDtos = _mapper.Map<IEnumerable<UserRoleDto>>(userRoles);
			return ApiResponse<IEnumerable<UserRoleDto>>.Ok(userRoleDtos);
		}
	}
}
