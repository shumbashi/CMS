using Application.DTOs.UserDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Command
{
	public class UpdateUserCommand : IRequest<ApiResponse<UserDto>>
	{
		public UpdateUserDto UpdateUserDto { get; set; }
	}

	public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResponse<UserDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		

		public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userRepository = unitOfWork.UserRepository;
			_mapper = mapper;
			
		}

		public async Task<ApiResponse<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{

			var user = await _userRepository.GetByIdAsync(request.UpdateUserDto.Id);
			if (user == null)
				return ApiResponse<UserDto>.Fail("المستخدم غير موجود.");

			// تحديث بيانات المستخدم
			_mapper.Map(request.UpdateUserDto, user);
			await _unitOfWork.Commit();

			var userDto = _mapper.Map<UserDto>(user);
			return ApiResponse<UserDto>.Ok(userDto, "تم تعديل المستخدم بنجاح.");
		}
	}

}
