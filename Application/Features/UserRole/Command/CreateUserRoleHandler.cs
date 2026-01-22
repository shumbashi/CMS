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
	public class CreateUserRoleCommand : IRequest<ApiResponse<UserRoleDto>>
	{
		public CreateUserRoleDto CreateUserRoleDTO { get; set; }
	}

	public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, ApiResponse<UserRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRoleRepository _userRoleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateUserRoleDto> _validator;

		public CreateUserRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_userRoleRepository = _unitOfWork.UserRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<UserRoleDto>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreateUserRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<UserRoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var userRole = _mapper.Map<Domain.Entities.UserRole>(request.CreateUserRoleDTO);
			await _userRoleRepository.AddAsync(userRole);
			await _unitOfWork.Commit();

			var userRoleDto = _mapper.Map<UserRoleDto>(userRole);
			return ApiResponse<UserRoleDto>.Ok(userRoleDto, "تم إنشاء العلاقة بنجاح.");
		}
	}
}
