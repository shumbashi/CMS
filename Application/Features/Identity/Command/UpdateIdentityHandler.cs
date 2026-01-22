using Application.DTOs.IdentityDTO;
using Application.Helper;
using Application.Interfaces;
using Application.Interfaces.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.Command
{
	public class UpdateIdentityCommand : IRequest<ApiResponse<IdentityDto>>
	{
		public UpdateIdentityDto UpdateIdentityDTO { get; set; }
	}

	public class UpdateIdentityHandler : IRequestHandler<UpdateIdentityCommand, ApiResponse<IdentityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityRepository _identityRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateIdentityDto> _validator;

		public UpdateIdentityHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateIdentityDto> validator)
		{
			_unitOfWork = unitOfWork;
			_identityRepository = _unitOfWork.IdentityRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<IdentityDto>> Handle(UpdateIdentityCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.UpdateIdentityDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<IdentityDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var identity = await _identityRepository.GetByIdAsync(request.UpdateIdentityDTO.UserId);
			if (identity == null)
			{
				return ApiResponse<IdentityDto>.Fail("الهوية غير موجودة.");
			}

			_mapper.Map(request.UpdateIdentityDTO, identity);
			_identityRepository.Update(identity);
			await _unitOfWork.Commit();

			var identityDto = _mapper.Map<IdentityDto>(identity);
			return ApiResponse<IdentityDto>.Ok(identityDto, "تم تحديث الهوية بنجاح.");
		}
	}
}
