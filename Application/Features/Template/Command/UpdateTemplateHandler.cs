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
	public class UpdateTemplateCommand : IRequest<ApiResponse<TemplateDto>>
	{
		public UpdateTemplateDto UpdateTemplateDTO { get; set; }
	}

	public class UpdateTemplateHandler : IRequestHandler<UpdateTemplateCommand, ApiResponse<TemplateDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateTemplateDto> _validator;

		public UpdateTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateTemplateDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<TemplateDto>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.UpdateTemplateDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<TemplateDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var template = await _unitOfWork.TemplateRepository.GetByIdAsync(request.UpdateTemplateDTO.Id);
			if (template == null)
				return ApiResponse<TemplateDto>.Fail("القالب غير موجود.");

			_mapper.Map(request.UpdateTemplateDTO, template);
			await _unitOfWork.Commit();

			var templateDto = _mapper.Map<TemplateDto>(template);
			return ApiResponse<TemplateDto>.Ok(templateDto, "تم تعديل القالب بنجاح.");
		}
	}
}
