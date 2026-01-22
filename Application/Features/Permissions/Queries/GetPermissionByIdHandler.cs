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
	public class GetPermissionByIdQuery : IRequest<ApiResponse<PermissionDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, ApiResponse<PermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPermissionRepository _permissionRepository;
		private readonly IMapper _mapper;

		public GetPermissionByIdHandler(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = _unitOfWork.PermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<PermissionDto>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
		{
			var permission = await _permissionRepository.GetByIdAsync(request.Id);
			if (permission == null)
			{
				return ApiResponse<PermissionDto>.Fail("الصلاحية غير موجودة.");
			}

			var permissionDto = _mapper.Map<PermissionDto>(permission);
			return ApiResponse<PermissionDto>.Ok(permissionDto);
		}
	}
}
