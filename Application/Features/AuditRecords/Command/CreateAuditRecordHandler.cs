using Application.DTOs.AuditRecordDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AuditRecords.Command
{
	public class CreateAuditRecordCommand : IRequest<ApiResponse<AuditRecordDto>>
	{
		public CreateAuditRecordDto CreateAuditRecordDTO { get; set; }
	}

	public class CreateAuditRecordHandler : IRequestHandler<CreateAuditRecordCommand, ApiResponse<AuditRecordDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateAuditRecordDto> _validator;

		public CreateAuditRecordHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateAuditRecordDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<AuditRecordDto>> Handle(CreateAuditRecordCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateAuditRecordDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<AuditRecordDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var auditRecord = _mapper.Map<AuditRecord>(request.CreateAuditRecordDTO);
			await _unitOfWork.AuditRecordRepository.AddAsync(auditRecord);
			await _unitOfWork.Commit();

			var auditRecordDto = _mapper.Map<AuditRecordDto>(auditRecord);
			return ApiResponse<AuditRecordDto>.Ok(auditRecordDto, "تم إنشاء سجل التدقيق بنجاح.");
		}
	}

}
