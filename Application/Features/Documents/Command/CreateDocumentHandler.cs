using Application.DTOs.DocumentDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Documents.Command
{
	public class CreateDocumentCommand : IRequest<ApiResponse<DocumentDto>>
	{
		public CreateDocumentDto CreateDocumentDTO { get; set; }
	}

	public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, ApiResponse<DocumentDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateDocumentDto> _validator;

		public CreateDocumentHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateDocumentDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<DocumentDto>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateDocumentDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<DocumentDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var document = _mapper.Map<Document>(request.CreateDocumentDTO);
			await _unitOfWork.DocumentRepository.AddAsync(document);
			await _unitOfWork.Commit();

			var documentDto = _mapper.Map<DocumentDto>(document);
			return ApiResponse<DocumentDto>.Ok(documentDto, "تم إنشاء الوثيقة بنجاح.");
		}
	}
}
