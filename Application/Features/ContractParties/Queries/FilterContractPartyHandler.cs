using Application.DTOs.ContractPartyDTO;
using Application.Helper;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Queries
{
	public class FilterContractPartyQuery : IRequest<ApiResponse<IEnumerable<ContractPartyDto>>>
	{
		public string Filter { get; set; }
	}

	public class FilterContractPartyHandler : IRequestHandler<FilterContractPartyQuery, ApiResponse<IEnumerable<ContractPartyDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public FilterContractPartyHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<ContractPartyDto>>> Handle(FilterContractPartyQuery request, CancellationToken cancellationToken)
		{
			var contractParties = await _unitOfWork.ContractPartyRepository.FindAsync(c => c.ContractPartyName.Contains(request.Filter));
			var contractPartyDtos = _mapper.Map<IEnumerable<ContractPartyDto>>(contractParties);
			return ApiResponse<IEnumerable<ContractPartyDto>>.Ok(contractPartyDtos, "تم تطبيق الفلترة بنجاح.");
		}
	}
}
