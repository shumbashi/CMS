using Application.DTOs.UserRoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.UserRole.Command
{
	public class UpdateUserRoleCommand : IRequest<ApiResponse<UserRoleDto>>
	{
		public UpdateUserRoleDto UpdateUserRoleDTO { get; set; }
	}

	public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, ApiResponse<UserRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRoleRepository _userRoleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateUserRoleDto> _validator;

		public UpdateUserRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_userRoleRepository = _unitOfWork.UserRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<UserRoleDto>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdateUserRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<UserRoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب العلاقة من الريبو
			var userRole = await _userRoleRepository.GetByIdAsync(request.UpdateUserRoleDTO.Id);
			if (userRole == null)
			{
				return ApiResponse<UserRoleDto>.Fail("العلاقة غير موجودة.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdateUserRoleDTO, userRole);
			_userRoleRepository.Update(userRole);
			await _unitOfWork.Commit();

			var userRoleDto = _mapper.Map<UserRoleDto>(userRole);
			return ApiResponse<UserRoleDto>.Ok(userRoleDto, "تم تحديث العلاقة بنجاح.");
		}
	}
}
