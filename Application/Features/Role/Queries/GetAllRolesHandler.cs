using Application.DTOs.RoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Role.Queries
{
	public class GetAllRolesQuery : IRequest<ApiResponse<IEnumerable<RoleDto>>>
	{
	}

	public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, ApiResponse<IEnumerable<RoleDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;

		public GetAllRolesHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = _unitOfWork.RoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<RoleDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
		{
			var roles = await _roleRepository.GetAllAsync();
			if (roles == null || !roles.Any())
			{
				return ApiResponse<IEnumerable<RoleDto>>.Fail("لا توجد أدوار.");
			}

			var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
			return ApiResponse<IEnumerable<RoleDto>>.Ok(roleDtos);
		}
	}
}
