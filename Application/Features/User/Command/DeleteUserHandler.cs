using Application.Helper;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.User.Command
{
	public class DeleteUserCommand : IRequest<ApiResponse<bool>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResponse<bool>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteUserHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
			if (user == null)
				return ApiResponse<bool>.Fail("المستخدم غير موجود.");

			_unitOfWork.UserRepository.Delete(user);
			await _unitOfWork.Commit();
			return ApiResponse<bool>.Ok(true, "تم الحذف بنجاح.");
		}
	}
}
