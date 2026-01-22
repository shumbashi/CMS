using Application.DTOs.RolePermissionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolePermissions.Command
{
	public class UpdateRolePermissionCommand : IRequest<ApiResponse<RolePermissionDto>>
	{
		public UpdateRolePermissionDto UpdateRolePermissionDTO { get; set; }
	}

	public class UpdateRolePermissionHandler : IRequestHandler<UpdateRolePermissionCommand, ApiResponse<RolePermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRolePermissionRepository _rolePermissionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateRolePermissionDto> _validator;

		public UpdateRolePermissionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateRolePermissionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_rolePermissionRepository = _unitOfWork.RolePermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<RolePermissionDto>> Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdateRolePermissionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<RolePermissionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب العلاقة من الريبو
			var rolePermission = await _rolePermissionRepository.GetByIdAsync(request.UpdateRolePermissionDTO.Id);
			if (rolePermission == null)
			{
				return ApiResponse<RolePermissionDto>.Fail("العلاقة غير موجودة.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdateRolePermissionDTO, rolePermission);
			_rolePermissionRepository.Update(rolePermission);
			await _unitOfWork.Commit();

			var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermission);
			return ApiResponse<RolePermissionDto>.Ok(rolePermissionDto, "تم تحديث العلاقة بين الدور والصلاحية بنجاح.");
		}
	}
}
