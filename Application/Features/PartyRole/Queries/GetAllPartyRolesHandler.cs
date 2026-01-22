using Application.DTOs.PartyRoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PartyRole.Queries
{
	public class GetAllPartyRolesQuery : IRequest<ApiResponse<IEnumerable<PartyRoleDto>>>
	{
	}

	public class GetAllPartyRolesHandler : IRequestHandler<GetAllPartyRolesQuery, ApiResponse<IEnumerable<PartyRoleDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPartyRoleRepository _partyRoleRepository;
		private readonly IMapper _mapper;

		public GetAllPartyRolesHandler(IUnitOfWork unitOfWork, IPartyRoleRepository partyRoleRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_partyRoleRepository = _unitOfWork.PartyRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<PartyRoleDto>>> Handle(GetAllPartyRolesQuery request, CancellationToken cancellationToken)
		{
			var partyRoles = await _partyRoleRepository.GetAllAsync();
			if (partyRoles == null || !partyRoles.Any())
			{
				return ApiResponse<IEnumerable<PartyRoleDto>>.Fail("لا توجد أدوار.");
			}

			var partyRoleDtos = _mapper.Map<IEnumerable<PartyRoleDto>>(partyRoles);
			return ApiResponse<IEnumerable<PartyRoleDto>>.Ok(partyRoleDtos);
		}
	}
}
