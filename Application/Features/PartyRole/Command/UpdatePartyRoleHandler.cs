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
	public class UpdatePartyRoleCommand : IRequest<ApiResponse<PartyRoleDto>>
	{
		public UpdatePartyRoleDto UpdatePartyRoleDTO { get; set; }
	}

	public class UpdatePartyRoleHandler : IRequestHandler<UpdatePartyRoleCommand, ApiResponse<PartyRoleDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IPartyRoleRepository _partyRoleRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdatePartyRoleDto> _validator;

		public UpdatePartyRoleHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePartyRoleDto> validator)
		{
			_unitOfWork = unitOfWork;
			_partyRoleRepository = _unitOfWork.PartyRoleRepository;  // الحصول على الريبو من الـ UnitOfWork
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<PartyRoleDto>> Handle(UpdatePartyRoleCommand request, CancellationToken cancellationToken)
		{
			// التحقق من صحة البيانات
			var validationResult = await _validator.ValidateAsync(request.UpdatePartyRoleDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<PartyRoleDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			// جلب الدور من الريبو
			var partyRole = await _partyRoleRepository.GetByIdAsync(request.UpdatePartyRoleDTO.Id);
			if (partyRole == null)
			{
				return ApiResponse<PartyRoleDto>.Fail("الدور غير موجود.");
			}

			// تحديث البيانات
			_mapper.Map(request.UpdatePartyRoleDTO, partyRole);
			_partyRoleRepository.Update(partyRole);
			await _unitOfWork.Commit();

			var partyRoleDto = _mapper.Map<PartyRoleDto>(partyRole);
			return ApiResponse<PartyRoleDto>.Ok(partyRoleDto, "تم تحديث الدور بنجاح.");
		}
	}
}
