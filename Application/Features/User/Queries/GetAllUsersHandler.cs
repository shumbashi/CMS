using Application.DTOs.UserDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Queries
{
	public class GetAllUsersQuery : IRequest<ApiResponse<IEnumerable<UserDto>>>
	{
	}

	public class GetallUsersHandler : IRequestHandler<GetAllUsersQuery, ApiResponse<IEnumerable<UserDto>>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetallUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userRepository = unitOfWork.UserRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetAllAsync();
			var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
			return ApiResponse<IEnumerable<UserDto>>.Ok(userDtos, "تم جلب المستخدمين بنجاح.");
		}
	}
}
