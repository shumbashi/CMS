using Application.DTOs.AuditRecordDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AuditRecords.Queries
{
	public class GetAuditRecordByIdQuery : IRequest<ApiResponse<AuditRecordDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetAuditRecordByIdHandler : IRequestHandler<GetAuditRecordByIdQuery, ApiResponse<AuditRecordDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAuditRecordByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<AuditRecordDto>> Handle(GetAuditRecordByIdQuery request, CancellationToken cancellationToken)
		{
			var auditRecord = await _unitOfWork.AuditRecordRepository.GetByIdAsync(request.Id);
			if (auditRecord == null)
			{
				return ApiResponse<AuditRecordDto>.Fail("سجل التدقيق غير موجود.");
			}

			var auditRecordDto = _mapper.Map<AuditRecordDto>(auditRecord);
			return ApiResponse<AuditRecordDto>.Ok(auditRecordDto);
		}
	}
}
