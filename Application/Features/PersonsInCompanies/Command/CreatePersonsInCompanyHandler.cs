using Application.DTOs.PersonsInCompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PersonsInCompanies.Command
{
	public class CreatePersonsInCompanyCommand : IRequest<ApiResponse<PersonsInCompanyDto>>
	{
		public CreatePersonsInCompanyDto CreatePersonsInCompanyDTO { get; set; }
	}

	public class CreatePersonsInCompanyHandler : IRequestHandler<CreatePersonsInCompanyCommand, ApiResponse<PersonsInCompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPersonsInCompanyRepository _personsInCompanyRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreatePersonsInCompanyDto> _validator;

		public CreatePersonsInCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePersonsInCompanyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_personsInCompanyRepository = _unitOfWork.PersonsInCompanyRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PersonsInCompanyDto>> Handle(CreatePersonsInCompanyCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreatePersonsInCompanyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PersonsInCompanyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var personsInCompany = _mapper.Map<PersonsInCompany>(request.CreatePersonsInCompanyDTO);
			await _personsInCompanyRepository.AddAsync(personsInCompany);
			await _unitOfWork.Commit();

			var personsInCompanyDto = _mapper.Map<PersonsInCompanyDto>(personsInCompany);
			return ApiResponse<PersonsInCompanyDto>.Ok(personsInCompanyDto, "تم إنشاء الشخص في الشركة بنجاح.");
		}
	}
}
