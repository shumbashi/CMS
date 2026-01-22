using Application.DTOs.AuditRecordDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AuditRecords.Command
{
	public class UpdateAuditRecordCommand : IRequest<ApiResponse<AuditRecordDto>>
	{
		public UpdateAuditRecordDto UpdateAuditRecordDTO { get; set; }
	}

	public class UpdateAuditRecordHandler : IRequestHandler<UpdateAuditRecordCommand, ApiResponse<AuditRecordDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateAuditRecordDto> _validator;

		public UpdateAuditRecordHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateAuditRecordDto> validator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<AuditRecordDto>> Handle(UpdateAuditRecordCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateAuditRecordDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<AuditRecordDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var auditRecord = await _unitOfWork.AuditRecordRepository.GetByIdAsync(request.UpdateAuditRecordDTO.Id);
			if (auditRecord == null)
			{
				return ApiResponse<AuditRecordDto>.Fail("سجل التدقيق غير موجود.");
			}

			_mapper.Map(request.UpdateAuditRecordDTO, auditRecord);
			_unitOfWork.AuditRecordRepository.Update(auditRecord);
			await _unitOfWork.Commit();

			var auditRecordDto = _mapper.Map<AuditRecordDto>(auditRecord);
			return ApiResponse<AuditRecordDto>.Ok(auditRecordDto, "تم تحديث سجل التدقيق بنجاح.");
		}
	}
}
