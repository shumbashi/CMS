using Application.DTOs.TemplateDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Command
{
	public class CreateTemplateCommand : IRequest<ApiResponse<TemplateDto>>
	{
		public CreateTemplateDto CreateTemplateDTO { get; set; }
	}

	public class CreateTemplateHandler : IRequestHandler<CreateTemplateCommand, ApiResponse<TemplateDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateTemplateDto> _validator;

		public CreateTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTemplateDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<TemplateDto>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.CreateTemplateDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<TemplateDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var template = _mapper.Map<Domain.Entities.Template>(request.CreateTemplateDTO);
			await _unitOfWork.TemplateRepository.AddAsync(template);
			await _unitOfWork.Commit();

			var templateDto = _mapper.Map<TemplateDto>(template);
			return ApiResponse<TemplateDto>.Ok(templateDto, "تم إنشاء القالب بنجاح.");
		}
	}
}
