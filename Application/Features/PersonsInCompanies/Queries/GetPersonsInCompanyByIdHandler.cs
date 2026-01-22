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
	public class GetPersonsInCompanyByIdQuery : IRequest<ApiResponse<PersonsInCompanyDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetPersonsInCompanyByIdHandler : IRequestHandler<GetPersonsInCompanyByIdQuery, ApiResponse<PersonsInCompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPersonsInCompanyRepository _personsInCompanyRepository;
		private readonly IMapper _mapper;

		public GetPersonsInCompanyByIdHandler(IUnitOfWork unitOfWork, IPersonsInCompanyRepository personsInCompanyRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_personsInCompanyRepository = _unitOfWork.PersonsInCompanyRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
		}

		public async Task<ApiResponse<PersonsInCompanyDto>> Handle(GetPersonsInCompanyByIdQuery request, CancellationToken cancellationToken)
		{
			var personsInCompany = await _personsInCompanyRepository.GetByIdAsync(request.Id);
			if (personsInCompany == null)
			{
				return ApiResponse<PersonsInCompanyDto>.Fail("الشخص في الشركة غير موجود.");
			}

			var personsInCompanyDto = _mapper.Map<PersonsInCompanyDto>(personsInCompany);
			return ApiResponse<PersonsInCompanyDto>.Ok(personsInCompanyDto);
		}
	}
}
