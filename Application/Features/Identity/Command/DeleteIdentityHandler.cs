using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.Command
{
	public class DeleteIdentityCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteIdentityHandler : IRequestHandler<DeleteIdentityCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityRepository _identityRepository;

		public DeleteIdentityHandler(IUnitOfWork unitOfWork,IIdentityRepository identityRepository)
		{
			_unitOfWork = unitOfWork;
			_identityRepository = unitOfWork.IdentityRepository;
		}

		public async Task<ApiResponse<string>> Handle( DeleteIdentityCommand request, CancellationToken cancellationToken)
		{
			var identity = await _identityRepository.GetByIdAsync(request.Id);
			if (identity == null)
			{
				return ApiResponse<string>.Fail("الهوية غير موجودة.");
			}

			_identityRepository.Delete(identity);
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم حذف الهوية بنجاح.");
		}
	}
}
