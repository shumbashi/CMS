using Application.DTOs.PermissionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Queries
{
	public class GetAllPermissionsQuery : IRequest<ApiResponse<IEnumerable<PermissionDto>>>
	{
	}

	public class GetAllPermissionsHandler : IRequestHandler<GetAllPermissionsQuery, ApiResponse<IEnumerable<PermissionDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPermissionRepository _permissionRepository;
		private readonly IMapper _mapper;

		public GetAllPermissionsHandler(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = _unitOfWork.PermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<PermissionDto>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
		{
			var permissions = await _permissionRepository.GetAllAsync();
			if (permissions == null || !permissions.Any())
			{
				return ApiResponse<IEnumerable<PermissionDto>>.Fail("لا توجد صلاحيات.");
			}

			var permissionDtos = _mapper.Map<IEnumerable<PermissionDto>>(permissions);
			return ApiResponse<IEnumerable<PermissionDto>>.Ok(permissionDtos);
		}
	}
}
