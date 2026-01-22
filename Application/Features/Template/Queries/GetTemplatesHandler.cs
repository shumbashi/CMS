using Application.DTOs.TemplateDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Template.Queries
{
	public class GetAllTemplatesQuery : IRequest<ApiResponse<IEnumerable<TemplateDto>>>
	{
		// يمكن إضافة خصائص للفلترة إذا لزم الأمر
	}
	public class GetTemplatesHandler : IRequestHandler<GetAllTemplatesQuery, ApiResponse<IEnumerable<TemplateDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetTemplatesHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<TemplateDto>>> Handle(GetAllTemplatesQuery request, CancellationToken cancellationToken)
		{
			// استرجاع كل الـ Templates
			var templates = await _unitOfWork.TemplateRepository.GetAllAsync();

			// تحويل البيانات إلى DTO
			var templateDtos = _mapper.Map<IEnumerable<TemplateDto>>(templates);

			// إرجاع النتيجة
			return ApiResponse<IEnumerable<TemplateDto>>.Ok(templateDtos, "تم جلب كل القوالب بنجاح.");
		}
	}
	}
