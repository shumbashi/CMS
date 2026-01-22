using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ContractPartyInDocuments.Command
{
	public class DeleteContractPartyInDocumentCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteContractPartyInDocumentHandler : IRequestHandler<DeleteContractPartyInDocumentCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IContractPartyInDocumentRepository _contractPartyInDocumentRepository;

		public DeleteContractPartyInDocumentHandler(IUnitOfWork unitOfWork, IContractPartyInDocumentRepository contractPartyInDocumentRepository )
		{
			_unitOfWork = unitOfWork;
			_contractPartyInDocumentRepository = unitOfWork.ContractPartyInDocumentRepository; // الحصول على الريبو من الوحدة

			
		}

		public async Task<ApiResponse<string>> Handle(DeleteContractPartyInDocumentCommand request, CancellationToken cancellationToken)
		{
			var contractPartyInDocument = await _contractPartyInDocumentRepository.GetByIdAsync(request.Id);
			if (contractPartyInDocument == null)
			{
				return ApiResponse<string>.Fail("الطرف في الوثيقة غير موجود.");
			}

			_contractPartyInDocumentRepository.Delete(contractPartyInDocument);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف الطرف في الوثيقة بنجاح.");
		}
	}

}
