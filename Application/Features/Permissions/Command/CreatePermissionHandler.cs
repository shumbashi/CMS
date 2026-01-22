using Application.DTOs.PermissionDTO;
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

namespace Application.Features.Permissions.Command
{
	public class CreatePermissionCommand : IRequest<ApiResponse<PermissionDto>>
	{
		public CreatePermissionDto CreatePermissionDTO { get; set; }
	}

	public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, ApiResponse<PermissionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPermissionRepository _permissionRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreatePermissionDto> _validator;

		public CreatePermissionHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePermissionDto> validator)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = _unitOfWork.PermissionRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PermissionDto>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreatePermissionDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PermissionDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var permission = _mapper.Map<Permission>(request.CreatePermissionDTO);
			await _permissionRepository.AddAsync(permission);
			await _unitOfWork.Commit();

			var permissionDto = _mapper.Map<PermissionDto>(permission);
			return ApiResponse<PermissionDto>.Ok(permissionDto, "تم إنشاء الصلاحية بنجاح.");
		}
	}
}
