using Application.DTOs.CompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Company.Queries
{
	public class GetAllCompaniesQuery : IRequest<ApiResponse<IEnumerable<CompanyDto>>>
	{
	}

	public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, ApiResponse<IEnumerable<CompanyDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;

		public GetAllCompaniesHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_companyRepository = _unitOfWork.CompanyRepository;  // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<CompanyDto>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
		{
			var companies = await _companyRepository.GetAllAsync();
			if (companies == null || !companies.Any())
			{
				return ApiResponse<IEnumerable<CompanyDto>>.Fail("لا توجد شركات.");
			}


			var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
			return ApiResponse<IEnumerable<CompanyDto>>.Ok(companyDtos);
		}
	}
}
