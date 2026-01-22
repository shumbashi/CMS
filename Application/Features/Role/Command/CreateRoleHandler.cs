using Application.DTOs.RoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Role.Command
{
	public class CreateRoleCommand : IRequest<ApiResponse<RoleDto>>
	{
		public CreateRoleDto CreateRoleDTO { get; set; }
	}

	public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, ApiResponse<RoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateRoleDto> _validator;

		public CreateRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = _unitOfWork.RoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<RoleDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreateRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<RoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var role = _mapper.Map<Domain.Entities.Role>(request.CreateRoleDTO);
			await _roleRepository.AddAsync(role);
			await _unitOfWork.Commit();

			var roleDto = _mapper.Map<RoleDto>(role);
			return ApiResponse<RoleDto>.Ok(roleDto, "تم إنشاء الدور بنجاح.");
		}
	}
}
