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
	public class GetAllContractPartiesQuery : IRequest<ApiResponse<IEnumerable<ContractPartyDto>>>
	{
		// يمكن إضافة خصائص هنا للفلترة إذا لزم الأمر
	}
	public class GetContractPartiesHandler : IRequestHandler<GetAllContractPartiesQuery, ApiResponse<IEnumerable<ContractPartyDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetContractPartiesHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<IEnumerable<ContractPartyDto>>> Handle(GetAllContractPartiesQuery request, CancellationToken cancellationToken)
		{
			
			var contractParties = await _unitOfWork.ContractPartyRepository.GetAllAsync();

			var contractPartyDtos = _mapper.Map<IEnumerable<ContractPartyDto>>(contractParties);

			return ApiResponse<IEnumerable<ContractPartyDto>>.Ok(contractPartyDtos, "تم جلب جميع الأطراف بنجاح.");
		}
	}
}
