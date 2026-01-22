using Application.DTOs.TemplateFieldDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.TemplateField.Command
{
	public class UpdateTemplateFieldCommand : IRequest<ApiResponse<TemplateFieldDto>>
	{
		public UpdateTemplateFieldDto UpdateTemplateFieldDTO { get; set; }
	}

	public class UpdateTemplateFieldHandler : IRequestHandler<UpdateTemplateFieldCommand, ApiResponse<TemplateFieldDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITemplateFieldRepository _templateFieldRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateTemplateFieldDto> _validator;

		public UpdateTemplateFieldHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateTemplateFieldDto> validator)
		{
			_unitOfWork = unitOfWork;
			_templateFieldRepository = unitOfWork.TemplateFieldRepository; // الحصول على الريبو من الوحدة
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<TemplateFieldDto>> Handle(UpdateTemplateFieldCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateTemplateFieldDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<TemplateFieldDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var templateField = await _templateFieldRepository.GetByIdAsync(request.UpdateTemplateFieldDTO.Id);
			if (templateField == null)
			{
				return ApiResponse<TemplateFieldDto>.Fail("حقل القالب غير موجود.");
			}

			_mapper.Map(request.UpdateTemplateFieldDTO, templateField);
			_templateFieldRepository.Update(templateField);
			await _unitOfWork.Commit();

			var templateFieldDto = _mapper.Map<TemplateFieldDto>(templateField);
			return ApiResponse<TemplateFieldDto>.Ok(templateFieldDto, "تم تحديث حقل القالب بنجاح.");
		}
	}
}
