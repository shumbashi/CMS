using Application.DTOs.PartyRoleDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.PartyRole.Command
{
	public class CreatePartyRoleCommand : IRequest<ApiResponse<PartyRoleDto>>
	{
		public CreatePartyRoleDto CreatePartyRoleDTO { get; set; }
	}

	public class CreatePartyRoleHandler : IRequestHandler<CreatePartyRoleCommand, ApiResponse<PartyRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPartyRoleRepository _partyRoleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreatePartyRoleDto> _validator;

		public CreatePartyRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePartyRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_partyRoleRepository = _unitOfWork.PartyRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PartyRoleDto>> Handle(CreatePartyRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.CreatePartyRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PartyRoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// تحويل الـ DTO إلى الكائن
			var partyRole = _mapper.Map<Domain.Entities.PartyRole>(request.CreatePartyRoleDTO);
			await _partyRoleRepository.AddAsync(partyRole);
			await _unitOfWork.Commit();

			var partyRoleDto = _mapper.Map<PartyRoleDto>(partyRole);
			return ApiResponse<PartyRoleDto>.Ok(partyRoleDto, "تم إنشاء الدور بنجاح.");
		}
	}
}
