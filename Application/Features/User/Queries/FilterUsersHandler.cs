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
	public class FilterUsersQuery : IRequest<ApiResponse<IEnumerable<UserDto>>>
	{
		public string Name { get; set; }
	}

	public class FilterUsersHandler : IRequestHandler<FilterUsersQuery, ApiResponse<IEnumerable<UserDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public FilterUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_userRepository = unitOfWork.UserRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<UserDto>>> Handle(FilterUsersQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.FindAsync(u => u.Name.Contains(request.Name));
			var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
			return ApiResponse<IEnumerable<	UserDto>>.Ok(userDtos, "تم تطبيق الفلترة بنجاح.");
		}
	}
}
