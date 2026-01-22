using Application.DTOs.CompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Company.Command
{
	public class UpdateCompanyCommand : IRequest<ApiResponse<CompanyDto>>
	{
		public UpdateCompanyDto UpdateCompanyDTO { get; set; }
	}

	public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, ApiResponse<CompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateCompanyDto> _validator;

		public UpdateCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCompanyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_companyRepository = unitOfWork.CompanyRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<CompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateCompanyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<CompanyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var company = await _companyRepository.GetByIdAsync(request.UpdateCompanyDTO.Id);
			if (company == null)
			{
				return ApiResponse<CompanyDto>.Fail("الشركة غير موجودة.");
			}

			_mapper.Map(request.UpdateCompanyDTO, company);
			_companyRepository.Update(company);
			await _unitOfWork.Commit();

			var companyDto = _mapper.Map<CompanyDto>(company);
			return ApiResponse<CompanyDto>.Ok(companyDto, "تم تحديث الشركة بنجاح.");
		}
	}

}
