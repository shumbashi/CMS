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
	public class GetPartyRoleByIdQuery : IRequest<ApiResponse<PartyRoleDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetPartyRoleByIdHandler : IRequestHandler<GetPartyRoleByIdQuery, ApiResponse<PartyRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPartyRoleRepository _partyRoleRepository;
		private readonly IMapper _mapper;

		public GetPartyRoleByIdHandler(IUnitOfWork unitOfWork, IPartyRoleRepository partyRoleRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_partyRoleRepository = _unitOfWork.PartyRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<PartyRoleDto>> Handle(GetPartyRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var partyRole = await _partyRoleRepository.GetByIdAsync(request.Id);
			if (partyRole == null)
			{
				return ApiResponse<PartyRoleDto>.Fail("الدور غير موجود.");
			}

			var partyRoleDto = _mapper.Map<PartyRoleDto>(partyRole);
			return ApiResponse<PartyRoleDto>.Ok(partyRoleDto);
		}
	}
}
