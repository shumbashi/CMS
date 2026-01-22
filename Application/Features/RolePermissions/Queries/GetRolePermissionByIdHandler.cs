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
	public class GetRolePermissionByIdQuery : IRequest<ApiResponse<RolePermissionDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetRolePermissionByIdHandler : IRequestHandler<GetRolePermissionByIdQuery, ApiResponse<RolePermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRolePermissionRepository _rolePermissionRepository;
		private readonly IMapper _mapper;

		public GetRolePermissionByIdHandler(IUnitOfWork unitOfWork, IRolePermissionRepository rolePermissionRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_rolePermissionRepository = _unitOfWork.RolePermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<RolePermissionDto>> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
		{
			var rolePermission = await _rolePermissionRepository.GetByIdAsync(request.Id);
			if (rolePermission == null)
			{
				return ApiResponse<RolePermissionDto>.Fail("العلاقة بين الدور والصلاحية غير موجودة.");
			}

			var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermission);
			return ApiResponse<RolePermissionDto>.Ok(rolePermissionDto);
		}
	}
}
