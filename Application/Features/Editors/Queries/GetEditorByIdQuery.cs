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
	public class GetEditorByIdQuery : IRequest<ApiResponse<EditorDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetEditorByIdHandler : IRequestHandler<GetEditorByIdQuery, ApiResponse<EditorDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetEditorByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<EditorDto>> Handle(GetEditorByIdQuery request, CancellationToken cancellationToken)
		{
			var editor = await _unitOfWork.EditorRepository.GetByIdAsync(request.Id);
			if (editor == null)
				return ApiResponse<EditorDto>.Fail("المحرر غير موجود.");

			var editorDto = _mapper.Map<EditorDto>(editor);
			return ApiResponse<EditorDto>.Ok(editorDto, "تم جلب المحرر بنجاح.");
		}
	}
}
