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
	public class GetCompanyByIdQuery : IRequest<ApiResponse<CompanyDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, ApiResponse<CompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;

		public GetCompanyByIdHandler(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_companyRepository = _unitOfWork.CompanyRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		public async Task<ApiResponse<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
		{
			var company = await _companyRepository.GetByIdAsync(request.Id);
			if (company == null)
			{
				return ApiResponse<CompanyDto>.Fail("الشركة غير موجودة.");
			}

			var companyDto = _mapper.Map<CompanyDto>(company);
			return ApiResponse<CompanyDto>.Ok(companyDto);
		}
	}
}
