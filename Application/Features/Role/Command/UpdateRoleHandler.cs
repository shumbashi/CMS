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
	public class UpdateRoleCommand : IRequest<ApiResponse<RoleDto>>
	{
		public UpdateRoleDto UpdateRoleDTO { get; set; }
	}

	public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, ApiResponse<RoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateRoleDto> _validator;

		public UpdateRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_roleRepository = _unitOfWork.RoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<RoleDto>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdateRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<RoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب الدور من الريبو
			var role = await _roleRepository.GetByIdAsync(request.UpdateRoleDTO.Id);
			if (role == null)
			{
				return ApiResponse<RoleDto>.Fail("الدور غير موجود.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdateRoleDTO, role);
			_roleRepository.Update(role);
			await _unitOfWork.Commit();

			var roleDto = _mapper.Map<RoleDto>(role);
			return ApiResponse<RoleDto>.Ok(roleDto, "تم تحديث الدور بنجاح.");
		}
	}
}
