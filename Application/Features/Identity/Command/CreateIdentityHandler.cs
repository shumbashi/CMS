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
	public class CreateIdentityCommand : IRequest<ApiResponse<IdentityDto>>
	{
		public CreateIdentityDto CreateIdentityDTO { get; set; }
	}

	public class CreateIdentityHandler : IRequestHandler<CreateIdentityCommand, ApiResponse<IdentityDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityRepository _identityRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateIdentityDto> _validator;

		public CreateIdentityHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateIdentityDto> validator)
		{
			_unitOfWork = unitOfWork;
			_identityRepository = _unitOfWork.IdentityRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<ApiResponse<IdentityDto>> Handle(CreateIdentityCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.CreateIdentityDTO);
			if (!validationResult.IsValid)
			{
				return ApiResponse<IdentityDto>.Fail(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
			}

			var identity = _mapper.Map<Domain.Entities.Identity>(request.CreateIdentityDTO);
			await _identityRepository.AddAsync(identity);
			await _unitOfWork.Commit();

			var identityDto = _mapper.Map<IdentityDto>(identity);
			return ApiResponse<IdentityDto>.Ok(identityDto, "تم إنشاء الهوية بنجاح.");
		}
	}
}
