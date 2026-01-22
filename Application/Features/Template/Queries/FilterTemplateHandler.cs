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
	public class FilterTemplateQuery : IRequest<ApiResponse<IEnumerable<TemplateDto>>>
	{
		public string Filter { get; set; }
	}

	public class FilterTemplateHandler : IRequestHandler<FilterTemplateQuery, ApiResponse<IEnumerable<TemplateDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public FilterTemplateHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<TemplateDto>>> Handle(FilterTemplateQuery request, CancellationToken cancellationToken)
		{
			var templates = await _unitOfWork.TemplateRepository.FindAsync(t => t.TemplateName.Contains(request.Filter));
			var templateDtos = _mapper.Map<IEnumerable<TemplateDto>>(templates);
			return ApiResponse<IEnumerable<TemplateDto>>.Ok(templateDtos, "تم تطبيق الفلترة بنجاح.");
		}
	}
}
