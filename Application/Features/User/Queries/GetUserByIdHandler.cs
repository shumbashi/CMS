using Application.DTOs.UserDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Queries
{
	public class GetUserByIdQuery : IRequest<ApiResponse<UserDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
			if (user == null)
				return ApiResponse<UserDto>.Fail("المستخدم غير موجود.");

			var userDto = _mapper.Map<UserDto>(user);
			return ApiResponse<UserDto>.Ok(userDto, "تم جلب المستخدم بنجاح.");
		}
	}
}
