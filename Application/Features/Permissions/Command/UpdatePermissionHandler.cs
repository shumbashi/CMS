using Application.DTOs.PermissionDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Permissions.Command
{
	public class UpdatePermissionCommand : IRequest<ApiResponse<PermissionDto>>
	{
		public UpdatePermissionDto UpdatePermissionDTO { get; set; }
	}

	public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, ApiResponse<PermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPermissionRepository _permissionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdatePermissionDto> _validator;

		public UpdatePermissionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePermissionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = _unitOfWork.PermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PermissionDto>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdatePermissionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PermissionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب الصلاحية من الريبو
			var permission = await _permissionRepository.GetByIdAsync(request.UpdatePermissionDTO.Id);
			if (permission == null)
			{
				return ApiResponse<PermissionDto>.Fail("الصلاحية غير موجودة.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdatePermissionDTO, permission);
			_permissionRepository.Update(permission);
			await _unitOfWork.Commit();

			var permissionDto = _mapper.Map<PermissionDto>(permission);
			return ApiResponse<PermissionDto>.Ok(permissionDto, "تم تحديث الصلاحية بنجاح.");
		}
	}
}
