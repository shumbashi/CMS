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
	public class GetTemplateByIdQuery : IRequest<ApiResponse<TemplateDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetTemplateByIdHandler : IRequestHandler<GetTemplateByIdQuery, ApiResponse<TemplateDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetTemplateByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<TemplateDto>> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
		{
			var template = await _unitOfWork.TemplateRepository.GetByIdAsync(request.Id);
			if (template == null)
				return ApiResponse<TemplateDto>.Fail("القالب غير موجود.");

			var templateDto = _mapper.Map<TemplateDto>(template);
			return ApiResponse<TemplateDto>.Ok(templateDto, "تم جلب القالب بنجاح.");
		}
	}
}
