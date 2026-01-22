using Application.DTOs.CompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Company.Command
{
	public class CreateCompanyCommand : IRequest<ApiResponse<CompanyDto>>
	{
		public CreateCompanyDto CreateCompanyDTO { get; set; }
	}

	public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, ApiResponse<CompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateCompanyDto> _validator;

		public CreateCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCompanyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_companyRepository = unitOfWork.CompanyRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateCompanyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<CompanyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var company = _mapper.Map<Domain.Entities.Company>(request.CreateCompanyDTO);
			await _companyRepository.AddAsync(company);
			await _unitOfWork.Commit();

			var companyDto = _mapper.Map<CompanyDto>(company);
			return ApiResponse<CompanyDto>.Ok(companyDto, "تم إنشاء الشركة بنجاح.");
		}
	}
}
