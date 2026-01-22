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
	public class GetAllAuditRecordsQuery : IRequest<ApiResponse<IEnumerable<AuditRecordDto>>>
	{
	}

	public class GetAllAuditRecordsHandler : IRequestHandler<GetAllAuditRecordsQuery, ApiResponse<IEnumerable<AuditRecordDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllAuditRecordsHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<AuditRecordDto>>> Handle(GetAllAuditRecordsQuery request, CancellationToken cancellationToken)
		{
			var auditRecords = await _unitOfWork.AuditRecordRepository.GetAllAsync();
			var auditRecordDtos = _mapper.Map<IEnumerable<AuditRecordDto>>(auditRecords);
			return ApiResponse<IEnumerable<AuditRecordDto>>.Ok(auditRecordDtos);
		}
	}
}
