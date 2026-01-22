using Application.DTOs.RolePermissionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolePermissions.Command
{
	public class CreateRolePermissionCommand : IRequest<ApiResponse<RolePermissionDto>>
	{
		public CreateRolePermissionDto CreateRolePermissionDTO { get; set; }
	}

	public class CreateRolePermissionHandler : IRequestHandler<CreateRolePermissionCommand, ApiResponse<RolePermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRolePermissionRepository _rolePermissionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateRolePermissionDto> _validator;

		public CreateRolePermissionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateRolePermissionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_rolePermissionRepository = _unitOfWork.RolePermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<RolePermissionDto>> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreateRolePermissionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<RolePermissionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var rolePermission = _mapper.Map<RolePermission>(request.CreateRolePermissionDTO);
			await _rolePermissionRepository.AddAsync(rolePermission);
			await _unitOfWork.Commit();

			var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermission);
			return ApiResponse<RolePermissionDto>.Ok(rolePermissionDto, "تم إنشاء العلاقة بين الدور والصلاحية بنجاح.");
		}
	}
}
