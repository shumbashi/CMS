using Application.DTOs.TemplateFieldDTO;
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

namespace Application.Features.TemplateField.Command
{
	public class CreateTemplateFieldCommand : IRequest<ApiResponse<TemplateFieldDto>>
	{
		public CreateTemplateFieldDto CreateTemplateFieldDTO { get; set; }
	}

	public class CreateTemplateFieldHandler : IRequestHandler<CreateTemplateFieldCommand, ApiResponse<TemplateFieldDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITemplateFieldRepository _templateFieldRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateTemplateFieldDto> _validator;

		public CreateTemplateFieldHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTemplateFieldDto> validator)
		{
			_unitOfWork = unitOfWork;
			_templateFieldRepository = unitOfWork.TemplateFieldRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<TemplateFieldDto>> Handle(CreateTemplateFieldCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateTemplateFieldDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<TemplateFieldDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var templateField = _mapper.Map<Domain.Entities.TemplateField>(request.CreateTemplateFieldDTO);

			await _templateFieldRepository.AddAsync(templateField);
			await _unitOfWork.Commit();

			var templateFieldDto = _mapper.Map<TemplateFieldDto>(templateField);
			return ApiResponse<TemplateFieldDto>.Ok(templateFieldDto, "تم إنشاء حقل القالب بنجاح.");
		}
	}
}
