using Application.DTOs.AttachmentDTO;
using Application.DTOs.AuditRecordDTO;
using Application.DTOs.CompanyDTO;
using Application.DTOs.ContractPartyDTO;
using Application.DTOs.ContractPartyInDocumentDTO;
using Application.DTOs.DocumentDTO;
using Application.DTOs.DocumentFieldDataDTO;
using Application.DTOs.EditorDTO;
using Application.DTOs.FinancialTransactionDTO;
using Application.DTOs.IdentityDTO;
using Application.DTOs.NotificationDTO;
using Application.DTOs.PartyRoleDTO;
using Application.DTOs.PermissionDTO;
using Application.DTOs.PersonsInCompanyDTO;
using Application.DTOs.UserDTO;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Editor
			ApplyPair(CreateMap<Editor, EditorDto>().ReverseMap());

			// FinancialTransaction
			ApplyPair(CreateMap<FinancialTransaction, FinancialTransactionDto>().ReverseMap());

			// Identity
			ApplyPair(CreateMap<Identity, IdentityDto>().ReverseMap());

			// Notification
			ApplyPair(CreateMap<Notification, NotificationDto>().ReverseMap());

			// PartyRole
			ApplyPair(CreateMap<PartyRole, PartyRoleDto>().ReverseMap());

			// Permission
			ApplyPair(CreateMap<Permission, PermissionDto>().ReverseMap());

			// PersonsInCompany
			ApplyPair(CreateMap<PersonsInCompany, PersonsInCompanyDto>().ReverseMap());

			// Attachment
			ApplyPair(CreateMap<Attachment, AttachmentDto>().ReverseMap());

			// AuditRecord
			ApplyPair(CreateMap<AuditRecord, AuditRecordDto>().ReverseMap());

			// Company
			ApplyPair(CreateMap<Company, CompanyDto>().ReverseMap());

			// ContractParty
			ApplyPair(CreateMap<ContractParty, ContractPartyDto>().ReverseMap());

			// ContractPartyInDocument
			ApplyPair(CreateMap<ContractPartyInDocument, ContractPartyInDocumentDto>().ReverseMap());

			// Document
			ApplyPair(CreateMap<Document, DocumentDto>().ReverseMap());

			// User
			ApplyPair(CreateMap<User, UserDto>().ReverseMap());

			// Create / Update maps (explicit DTO -> Entity)
			ApplyPair(CreateMap<CreateEditorDto, Editor>().ReverseMap());
			ApplyPair(CreateMap<UpdateEditorDto, Editor>().ReverseMap());

			ApplyPair(CreateMap<CreateFinancialTransactionDto, FinancialTransaction>().ReverseMap());
			ApplyPair(CreateMap<UpdateFinancialTransactionDto, FinancialTransaction>().ReverseMap());

			ApplyPair(CreateMap<CreateIdentityDto, Identity>().ReverseMap());
			ApplyPair(CreateMap<UpdateIdentityDto, Identity>().ReverseMap());

			ApplyPair(CreateMap<CreateNotificationDto, Notification>().ReverseMap());
			ApplyPair(CreateMap<UpdateNotificationDto, Notification>().ReverseMap());

			ApplyPair(CreateMap<CreatePartyRoleDto, PartyRole>().ReverseMap());
			ApplyPair(CreateMap<UpdatePartyRoleDto, PartyRole>().ReverseMap());

			ApplyPair(CreateMap<CreatePermissionDto, Permission>().ReverseMap());
			ApplyPair(CreateMap<UpdatePermissionDto, Permission>().ReverseMap());

			ApplyPair(CreateMap<CreatePersonsInCompanyDto, PersonsInCompany>().ReverseMap());
			ApplyPair(CreateMap<UpdatePersonsInCompanyDto, PersonsInCompany>().ReverseMap());

			ApplyPair(CreateMap<CreateAttachmentDto, Attachment>().ReverseMap());
			ApplyPair(CreateMap<UpdateAttachmentDto, Attachment>().ReverseMap());

			ApplyPair(CreateMap<CreateAuditRecordDto, AuditRecord>().ReverseMap());
			ApplyPair(CreateMap<UpdateAuditRecordDto, AuditRecord>().ReverseMap());

			ApplyPair(CreateMap<CreateCompanyDto, Company>().ReverseMap());
			ApplyPair(CreateMap<UpdateCompanyDto, Company>().ReverseMap());

			ApplyPair(CreateMap<CreateContractPartyDto, ContractParty>().ReverseMap());
			ApplyPair(CreateMap<UpdateContractPartyDto, ContractParty>().ReverseMap());

			ApplyPair(CreateMap<CreateContractPartyInDocumentDto, ContractPartyInDocument>().ReverseMap());
			ApplyPair(CreateMap<UpdateContractPartyInDocumentDto, ContractPartyInDocument>().ReverseMap());

			ApplyPair(CreateMap<CreateDocumentDto, Document>().ReverseMap());
			ApplyPair(CreateMap<UpdateDocumentDto, Document>().ReverseMap());

			ApplyPair(CreateMap<CreateUserDto, User>().ReverseMap());
			ApplyPair(CreateMap<UpdateUserDto, User>().ReverseMap());
		}

		// Helper: apply the same null/default-source-member condition to both mapping directions
		private void ApplyPair<TSource, TDestination>(IMappingExpression<TSource, TDestination> forward)
		{
			// Apply to forward mapping
			ApplyIgnoreNullCondition(forward);

			// If ReverseMap() was called before passing here, AutoMapper returned the reverse mapping expression.
			// Attempt to find and apply to the reverse mapping as well if available:
			// ReverseMap returns IMappingExpression<TDestination, TSource>, so try to cast.
			if (forward is IMappingExpression<TDestination, TSource> reverse)
			{
				ApplyIgnoreNullCondition(reverse);
				return;
			}

			// Some calls pass only a forward mapping (without ReverseMap). Nothing else required.
		}

		private void ApplyIgnoreNullCondition<TSource, TDestination>(IMappingExpression<TSource, TDestination> map)
		{
			map.ForAllMembers(opt =>
			{
				opt.Condition((src, dest, srcMember) =>
				{
					if (srcMember == null)
						return false;

					if (srcMember is Guid g && g == Guid.Empty)
						return false;

					// keep the value for non-null / non-default members
					return true;
				});
			});
		}
	}
}
