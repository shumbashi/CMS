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
	// Command لاسترجاع كل الهوية
	public class GetAllIdentitiesQuery : IRequest<ApiResponse<IEnumerable<IdentityDto>>>
	{
	}

	// Handler لاسترجاع كل الهوية
	public class GetAllIdentitiesHandler : IRequestHandler<GetAllIdentitiesQuery, ApiResponse<IEnumerable<IdentityDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityRepository _identityRepository;
		private readonly IMapper _mapper;

		public GetAllIdentitiesHandler(IUnitOfWork unitOfWork, IIdentityRepository identityRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_identityRepository = _unitOfWork.IdentityRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<IdentityDto>>> Handle(GetAllIdentitiesQuery request, CancellationToken cancellationToken)
		{
			// استرجاع كل الهوية من الريبو
			var identities = await _identityRepository.GetAllAsync();
			if (identities == null || identities.Count() == 0)
			{
				return ApiResponse<IEnumerable<IdentityDto>>.Fail("لا توجد هوية.");
			}

			// تحويل الـ Identity إلى IdentityDto
			var identityDtos = _mapper.Map<IEnumerable<IdentityDto>>(identities);

			// إرجاع النتيجة بنجاح
			return ApiResponse<IEnumerable<IdentityDto>>.Ok(identityDtos);
		}
	}
}
