using Application.DTOs.PersonsInCompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PersonsInCompanies.Queries
{
	public class GetAllPersonsInCompanyQuery : IRequest<ApiResponse<IEnumerable<PersonsInCompanyDto>>>
	{
	}

	public class GetAllPersonsInCompanyHandler : IRequestHandler<GetAllPersonsInCompanyQuery, ApiResponse<IEnumerable<PersonsInCompanyDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPersonsInCompanyRepository _personsInCompanyRepository;
		private readonly IMapper _mapper;

		public GetAllPersonsInCompanyHandler(IUnitOfWork unitOfWork, IPersonsInCompanyRepository personsInCompanyRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_personsInCompanyRepository = _unitOfWork.PersonsInCompanyRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<PersonsInCompanyDto>>> Handle(GetAllPersonsInCompanyQuery request, CancellationToken cancellationToken)
		{
			var personsInCompany = await _personsInCompanyRepository.GetAllAsync();
			if (personsInCompany == null || !personsInCompany.Any())
			{
				return ApiResponse<IEnumerable<PersonsInCompanyDto>>.Fail("لا توجد أشخاص في الشركة.");
			}

			var personsInCompanyDtos = _mapper.Map<IEnumerable<PersonsInCompanyDto>>(personsInCompany);
			return ApiResponse<IEnumerable<PersonsInCompanyDto>>.Ok(personsInCompanyDtos);
		}
	}
}
