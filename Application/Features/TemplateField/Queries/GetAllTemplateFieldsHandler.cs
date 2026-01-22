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
	public class GetAllTemplateFieldsQuery : IRequest<ApiResponse<IEnumerable<TemplateFieldDto>>>
	{
	}

	public class GetAllTemplateFieldsHandler : IRequestHandler<GetAllTemplateFieldsQuery, ApiResponse<IEnumerable<TemplateFieldDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITemplateFieldRepository _templateFieldRepository;
		private readonly IMapper _mapper;

		public GetAllTemplateFieldsHandler(IUnitOfWork unitOfWork, ITemplateFieldRepository templateFieldRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_templateFieldRepository = unitOfWork.TemplateFieldRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<TemplateFieldDto>>> Handle(GetAllTemplateFieldsQuery request, CancellationToken cancellationToken)
		{
			var templateFields = await _templateFieldRepository.GetAllAsync();
			var templateFieldDtos = _mapper.Map<IEnumerable<TemplateFieldDto>>(templateFields);
			return ApiResponse<IEnumerable<TemplateFieldDto>>.Ok(templateFieldDtos);
		}
	}
}
