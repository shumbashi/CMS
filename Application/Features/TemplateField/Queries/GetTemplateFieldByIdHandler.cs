using Application.DTOs.TemplateFieldDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.TemplateField.Queries
{
	// Command لاسترجاع TemplateField بواسطة الـ Id
	public class GetTemplateFieldByIdQuery : IRequest<ApiResponse<TemplateFieldDto>>
	{
		public Guid Id { get; set; }  // إضافة الـ FieldName (الذي يعتبر الـ Id)
	}

	// Handler لاسترجاع TemplateField بواسطة الـ Id
	public class GetTemplateFieldByIdHandler : IRequestHandler<GetTemplateFieldByIdQuery, ApiResponse<TemplateFieldDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITemplateFieldRepository _templateFieldRepository;
		private readonly IMapper _mapper;

		public GetTemplateFieldByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_templateFieldRepository = _unitOfWork.TemplateFieldRepository;  // الحصول على الريبو من الوحدة
			_mapper = mapper;
		}

		// تنفيذ المنطق الخاص بجلب TemplateField بواسطة الـ Id
		public async Task<ApiResponse<TemplateFieldDto>> Handle(GetTemplateFieldByIdQuery request, CancellationToken cancellationToken)
		{
			// استخدام الـ FieldName للبحث في الريبو
			var templateField = await _templateFieldRepository.GetByIdAsync(request.Id);

			// إذا لم يتم العثور على السجل
			if (templateField == null)
			{
				return ApiResponse<TemplateFieldDto>.Fail("حقل القالب غير موجود.");
			}

			// تحويل الكيان إلى DTO
			var templateFieldDto = _mapper.Map<TemplateFieldDto>(templateField);

			// إرجاع النتيجة بنجاح
			return ApiResponse<TemplateFieldDto>.Ok(templateFieldDto);
		}
	}
}
