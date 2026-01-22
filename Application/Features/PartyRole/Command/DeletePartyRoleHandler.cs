using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PartyRole.Command
{
	public class DeletePartyRoleCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeletePartyRoleHandler : IRequestHandler<DeletePartyRoleCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPartyRoleRepository _partyRoleRepository;

		public DeletePartyRoleHandler(IUnitOfWork unitOfWork, IPartyRoleRepository partyRoleRepository)
		{
			_unitOfWork = unitOfWork;
			_partyRoleRepository = _unitOfWork.PartyRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeletePartyRoleCommand request, CancellationToken cancellationToken)
		{
			var partyRole = await _partyRoleRepository.GetByIdAsync(request.Id);
			if (partyRole == null)
			{
				return ApiResponse<string>.Fail("الدور غير موجود.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			partyRole.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة الدور إلى محذوف.");
		}
	}
}
