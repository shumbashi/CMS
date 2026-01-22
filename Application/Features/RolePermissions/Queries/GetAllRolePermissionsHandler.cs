using Application.DTOs.RolePermissionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolePermissions.Queries
{
	public class GetAllRolePermissionsQuery : IRequest<ApiResponse<IEnumerable<RolePermissionDto>>>
	{
	}

	public class GetAllRolePermissionsHandler : IRequestHandler<GetAllRolePermissionsQuery, ApiResponse<IEnumerable<RolePermissionDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRolePermissionRepository _rolePermissionRepository;
		private readonly IMapper _mapper;

		public GetAllRolePermissionsHandler(IUnitOfWork unitOfWork, IRolePermissionRepository rolePermissionRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_rolePermissionRepository = _unitOfWork.RolePermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<RolePermissionDto>>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
		{
			var rolePermissions = await _rolePermissionRepository.GetAllAsync();
			if (rolePermissions == null || !rolePermissions.Any())
			{
				return ApiResponse<IEnumerable<RolePermissionDto>>.Fail("لا توجد علاقات بين الأدوار والصلاحيات.");
			}

			var rolePermissionDtos = _mapper.Map<IEnumerable<RolePermissionDto>>(rolePermissions);
			return ApiResponse<IEnumerable<RolePermissionDto>>.Ok(rolePermissionDtos);
		}
	}
}
