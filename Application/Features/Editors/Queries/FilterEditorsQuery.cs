using Application.DTOs.EditorDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Queries
{
	public class FilterEditorQuery : IRequest<ApiResponse<IEnumerable<EditorDto>>>
	{
		public FilterEditorDto FilterDto { get; set; }  // استخدام FilterEditorDto للفلترة
	}
	public class FilterEditorHandler : IRequestHandler<FilterEditorQuery, ApiResponse<IEnumerable<EditorDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEditorRepository _editorRepository;
		private readonly IMapper _mapper;

		public FilterEditorHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_editorRepository = unitOfWork.EditorRepository;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<EditorDto>>> Handle(FilterEditorQuery request, CancellationToken cancellationToken)
		{
			// استخدام الفلترة من الريبو
			var editorsQuery = await _editorRepository.FilterEditorsAsync(request.FilterDto);

			// تحويل النتائج إلى DTO
			var editorDtos = _mapper.Map<IEnumerable<EditorDto>>(editorsQuery);

			// إرجاع النتيجة
			return ApiResponse<IEnumerable<EditorDto>>.Ok(editorDtos, "تم تطبيق الفلترة بنجاح.");
		}
	}
}
