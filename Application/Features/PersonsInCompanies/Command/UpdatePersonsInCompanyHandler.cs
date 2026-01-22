using Application.DTOs.PersonsInCompanyDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PersonsInCompanies.Command
{
	public class UpdatePersonsInCompanyCommand : IRequest<ApiResponse<PersonsInCompanyDto>>
	{
		public UpdatePersonsInCompanyDto UpdatePersonsInCompanyDTO { get; set; }
	}

	public class UpdatePersonsInCompanyHandler : IRequestHandler<UpdatePersonsInCompanyCommand, ApiResponse<PersonsInCompanyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPersonsInCompanyRepository _personsInCompanyRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdatePersonsInCompanyDto> _validator;

		public UpdatePersonsInCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePersonsInCompanyDto> validator)
		{
			_unitOfWork = unitOfWork;
			_personsInCompanyRepository = _unitOfWork.PersonsInCompanyRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PersonsInCompanyDto>> Handle(UpdatePersonsInCompanyCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdatePersonsInCompanyDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PersonsInCompanyDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب الشخص في الشركة من الريبو
			var personsInCompany = await _personsInCompanyRepository.GetByIdAsync(request.UpdatePersonsInCompanyDTO.Id);
			if (personsInCompany == null)
			{
				return ApiResponse<PersonsInCompanyDto>.Fail("الشخص في الشركة غير موجود.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdatePersonsInCompanyDTO, personsInCompany);
			_personsInCompanyRepository.Update(personsInCompany);
			await _unitOfWork.Commit();

			var personsInCompanyDto = _mapper.Map<PersonsInCompanyDto>(personsInCompany);
			return ApiResponse<PersonsInCompanyDto>.Ok(personsInCompanyDto, "تم تحديث الشخص في الشركة بنجاح.");
		}
	}
}
