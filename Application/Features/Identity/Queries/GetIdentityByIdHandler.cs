using Application.DTOs.IdentityDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.Queries
{
	public class GetIdentityByIdQuery : IRequest<ApiResponse<IdentityDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetIdentityHandler : IRequestHandler<GetIdentityByIdQuery, ApiResponse<IdentityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityRepository _identityRepository;
		private readonly IMapper _mapper;

		public GetIdentityHandler(IUnitOfWork unitOfWork,IIdentityRepository identityRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_identityRepository = unitOfWork.IdentityRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IdentityDto>> Handle(GetIdentityByIdQuery request, CancellationToken cancellationToken)
		{
			var identity = await _identityRepository.GetByIdAsync(request.Id);
			if (identity == null)
			{
				return ApiResponse<IdentityDto>.Fail("الهوية غير موجودة.");
			}

			var identityDto = _mapper.Map<IdentityDto>(identity);
			return ApiResponse<IdentityDto>.Ok(identityDto);
		}
	}
}
