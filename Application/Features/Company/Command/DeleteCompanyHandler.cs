using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Company.Command
{
	public class DeleteCompanyCommand : IRequest<ApiResponse<string>>
	{
		public Guid Id { get; set; }
	}

	public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, ApiResponse<string>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;

		public DeleteCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper, ICompanyRepository companyRepository)
		{
			_unitOfWork = unitOfWork;
			_companyRepository = _unitOfWork.CompanyRepository;  
			_mapper = mapper;
		}

		public async Task<ApiResponse<string>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
		{
			var company = await _companyRepository.GetByIdAsync(request.Id);
			if (company == null)
			{
				return ApiResponse<string>.Fail("الشركة غير موجودة.");
			}

			// استخدام MarkAsDeleted بشكل مركزي
			company.MarkAsDeleted("تم الحذف منطقيًا");
			await _unitOfWork.Commit();  // تنفيذ التغييرات

			return ApiResponse<string>.Ok("تم تحديث حالة الشركة إلى محذوفة.");
		}
	}
}
