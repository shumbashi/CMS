using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PersonsInCompanies.Command
{
	public class DeletePersonsInCompanyCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeletePersonsInCompanyHandler : IRequestHandler<DeletePersonsInCompanyCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPersonsInCompanyRepository _personsInCompanyRepository;

		public DeletePersonsInCompanyHandler(IUnitOfWork unitOfWork, IPersonsInCompanyRepository personsInCompanyRepository)
		{
			_unitOfWork = unitOfWork;
			_personsInCompanyRepository = _unitOfWork.PersonsInCompanyRepository;  // الحصول على الريبو من الـ UnitOfWork
		}

		public async Task<ApiResponse<string>> Handle(DeletePersonsInCompanyCommand request, CancellationToken cancellationToken)
		{
			var personsInCompany = await _personsInCompanyRepository.GetByIdAsync(request.Id);
			if (personsInCompany == null)
			{
				return ApiResponse<string>.Fail("الشخص في الشركة غير موجود.");
			}

			// استخدام MarkAsDeleted للتصفية المنطقية
			personsInCompany.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();

			return ApiResponse<string>.Ok("تم تحديث حالة الشخص في الشركة إلى محذوف.");
		}
	}
}
