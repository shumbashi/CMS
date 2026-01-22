using Application.DTOs.DocumentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Command
{
	public class UpdateDocumentCommand : IRequest<ApiResponse<DocumentDto>>
	{
		public UpdateDocumentDto UpdateDocumentDTO { get; set; }
	}

	public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, ApiResponse<DocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateDocumentDto> _validator;

		public UpdateDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateDocumentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<DocumentDto>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateDocumentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<DocumentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var document = await _unitOfWork.DocumentRepository.GetByIdAsync(request.UpdateDocumentDTO.Id);
			if (document == null)
				return ApiResponse<DocumentDto>.Fail("الوثيقة غير موجودة.");

			_mapper.Map(request.UpdateDocumentDTO, document);
			await _unitOfWork.Commit();

			var documentDto = _mapper.Map<DocumentDto>(document);
			return ApiResponse<DocumentDto>.Ok(documentDto, "تم تعديل الوثيقة بنجاح.");
		}
	}
}
