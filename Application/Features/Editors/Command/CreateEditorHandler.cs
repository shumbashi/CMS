using Application.DTOs.EditorDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Editors.Command
{
	public class CreateEditorCommand : IRequest<ApiResponse<EditorDto>>
	{
		public CreateEditorDto CreateEditorDTO { get; set; }
	}

	public class CreateEditorHandler : IRequestHandler<CreateEditorCommand, ApiResponse<EditorDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateEditorDto> _validator;

		public CreateEditorHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateEditorDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<EditorDto>> Handle(CreateEditorCommand request, CancellationToken cancellationToken)
		{
			// التحقق من البيانات باستخدام Validator
			var validationResult = await _validator.ValidateAsync(request.CreateEditorDTO);
			if (!validationResult.IsValid)
			{
				// إذا كانت البيانات غير صحيحة، قم بإرجاع رسالة خطأ
				return ApiResponse<EditorDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var editor = _mapper.Map<Editor>(request.CreateEditorDTO);
			await _unitOfWork.EditorRepository.AddAsync(editor);
			await _unitOfWork.Commit();

			var editorDto = _mapper.Map<EditorDto>(editor);
			return ApiResponse<EditorDto>.Ok(editorDto, "تم إنشاء المحرر بنجاح.");
		}
	}
}
