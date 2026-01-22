using Application.DTOs.EditorDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
	public class UpdateEditorCommand : IRequest<ApiResponse<EditorDto>>
	{
		public UpdateEditorDto UpdateEditorDTO { get; set; }
	}

	public class UpdateEditorHandler : IRequestHandler<UpdateEditorCommand, ApiResponse<EditorDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateEditorDto> _validator;

		public UpdateEditorHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateEditorDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<EditorDto>> Handle(UpdateEditorCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.UpdateEditorDTO);
			if (!validationResult.IsValid)
			{
				// إذا كانت البيانات غير صحيحة، قم بإرجاع رسالة خطأ
				return ApiResponse<EditorDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var editor = await _unitOfWork.EditorRepository.GetByIdAsync(request.UpdateEditorDTO.Id);
			if (editor == null)
				return ApiResponse<EditorDto>.Fail("المحرر غير موجود.");

			_mapper.Map(request.UpdateEditorDTO, editor);
			await _unitOfWork.Commit();

			var editorDto = _mapper.Map<EditorDto>(editor);
			return ApiResponse<EditorDto>.Ok(editorDto, "تم تعديل المحرر بنجاح.");
		}
	}
}
