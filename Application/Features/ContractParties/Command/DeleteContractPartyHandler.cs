using Application.Helper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractParties.Command
{
	public class DeleteContractPartyCommand : IRequest<ApiResponse<bool>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteContractPartyHandler : IRequestHandler<DeleteContractPartyCommand, ApiResponse<bool>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteContractPartyHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(DeleteContractPartyCommand request, CancellationToken cancellationToken)
		{
			var contractParty = await _unitOfWork.ContractPartyRepository.GetByIdAsync(request.Id);
			if (contractParty == null)
				return ApiResponse<bool>.Fail("الطرف غير موجود.");

			_unitOfWork.ContractPartyRepository.Delete(contractParty);
			await _unitOfWork.Commit();
			return ApiResponse<bool>.Ok(true, "تم حذف الطرف بنجاح.");
		}
	}
}
