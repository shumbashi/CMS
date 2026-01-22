using Application.DTOs.EditorDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Queries
{
	public class GetAllEditorsQuery : IRequest<ApiResponse<IEnumerable<EditorDto>>>
	{
	}

	public class GetAllEditorsHandler : IRequestHandler<GetAllEditorsQuery, ApiResponse<IEnumerable<EditorDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllEditorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<EditorDto>>> Handle(GetAllEditorsQuery request, CancellationToken cancellationToken)
		{
			var editors = await _unitOfWork.EditorRepository.GetAllAsync();
			var editorDtos = _mapper.Map<IEnumerable<EditorDto>>(editors);
			return ApiResponse<IEnumerable<EditorDto>>.Ok(editorDtos, "تم جلب المحررين بنجاح.");
		}
	}
}
