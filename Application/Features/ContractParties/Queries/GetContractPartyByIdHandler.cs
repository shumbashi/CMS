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
	public class GetContractPartyByIdQuery : IRequest<ApiResponse<ContractPartyDto>>
	{
		public Guid Id { get; set; }
	}

	public class GetContractPartyByIdHandler : IRequestHandler<GetContractPartyByIdQuery, ApiResponse<ContractPartyDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetContractPartyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<ContractPartyDto>> Handle(GetContractPartyByIdQuery request, CancellationToken cancellationToken)
		{
			var contractParty = await _unitOfWork.ContractPartyRepository.GetByIdAsync(request.Id);
			if (contractParty == null)
				return ApiResponse<ContractPartyDto>.Fail("الطرف غير موجود.");

			var contractPartyDto = _mapper.Map<ContractPartyDto>(contractParty);
			return ApiResponse<ContractPartyDto>.Ok(contractPartyDto, "تم جلب الطرف بنجاح.");
		}
	}
}
