using Application.DTOs.UserDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Repository;
using Application.Resources;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Command
{
	public class CreateUserCommand : IRequest<ApiResponse<UserDto>>
	{
		public CreateUserDto CreateUserDto { get; set; }
	}

	public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateUserDto> _validator;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IStringLocalizer<SharedResources> _localizer;

		public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserDto> validator, IPasswordHasher passwordHasher, IStringLocalizer<SharedResources> localizer)
		{
			_unitOfWork = unitOfWork;
			_userRepository = unitOfWork.UserRepository;
			_mapper = mapper;
			_validator = validator;
			_passwordHasher = passwordHasher;
			_localizer = localizer;
		}

		public async Task<ApiResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			// ✅ التحقق من صحة البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.CreateUserDto);
			if (!validationResult.IsValid)
			{
				// إذا كانت البيانات غير صحيحة، قم بإرجاع رسالة خطأ
				var errors = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
				return ApiResponse<UserDto>.Fail(errors);
			}

			// ✅ التحقق من التكرار (الاسم، البريد الإلكتروني، ورقم الهاتف)
			var isUserExists = await _userRepository.ValidNameAndEmailAndPhoneAsync(
				request.CreateUserDto.Name,
				request.CreateUserDto.Email,
				request.CreateUserDto.Phone);

			if (isUserExists != null)
			{
				if (isUserExists.Name == request.CreateUserDto.Name)
					return ApiResponse<UserDto>.Fail(_localizer["اسم المستخدم موجود مسبقًا"]);

				if (isUserExists.Email == request.CreateUserDto.Email)
					return ApiResponse<UserDto>.Fail(_localizer["البريد الإلكتروني موجود مسبقًا"]);

				if (isUserExists.Phone == request.CreateUserDto.Phone)
					return ApiResponse<UserDto>.Fail(_localizer["رقم الهاتف موجود مسبقا"]);
			}

			// ✅ تحويل CreateUserDTO إلى كائن User
			var user = _mapper.Map<Domain.Entities.User>(request.CreateUserDto);

			// 🔒 عمل Hash لكلمة المرور
			user.Password = _passwordHasher.HashPassword(request.CreateUserDto.Password);

			// ✅ إضافة المستخدم إلى قاعدة البيانات
			await _userRepository.AddAsync(user);
			await _unitOfWork.Commit();

			// 🚫 إزالة كلمة المرور من الاستجابة
			user.Password = null;

			// ✅ تحويل الكائن User إلى DTO
			var dto = _mapper.Map<UserDto>(user);

			return ApiResponse<UserDto>.Ok(dto, "تم إنشاء المستخدم بنجاح.");
		}
	}

}


