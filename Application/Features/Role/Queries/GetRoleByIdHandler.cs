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
	public class GetRoleByIdQuery : IRequest<ApiResponse<RoleDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, ApiResponse<RoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;

		public GetRoleByIdHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = _unitOfWork.RoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var role = await _roleRepository.GetByIdAsync(request.Id);
			if (role == null)
			{
				return ApiResponse<RoleDto>.Fail("الدور غير موجود.");
			}

			var roleDto = _mapper.Map<RoleDto>(role);
			return ApiResponse<RoleDto>.Ok(roleDto);
		}
	}
}
