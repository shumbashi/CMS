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
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
	{
		// Editor
		CreateMap<Editor, EditorDto>().ReverseMap();
		CreateMap<CreateEditorDto, Editor>().ReverseMap();
		CreateMap<UpdateEditorDto, Editor>().ReverseMap();

		// FinancialTransaction
		CreateMap<FinancialTransaction, FinancialTransactionDto>().ReverseMap();
		CreateMap<CreateFinancialTransactionDto, FinancialTransaction>().ReverseMap();
		CreateMap<UpdateFinancialTransactionDto, FinancialTransaction>().ReverseMap();

		// Identity
		CreateMap<Identity, IdentityDto>().ReverseMap();
		CreateMap<CreateIdentityDto, Identity>().ReverseMap();
		CreateMap<UpdateIdentityDto, Identity>().ReverseMap();

		// Notification
		CreateMap<Notification, NotificationDto>().ReverseMap();
		CreateMap<CreateNotificationDto, Notification>().ReverseMap();
		CreateMap<UpdateNotificationDto, Notification>().ReverseMap();

		// PartyRole
		CreateMap<PartyRole, PartyRoleDto>().ReverseMap();
		CreateMap<CreatePartyRoleDto, PartyRole>().ReverseMap();
		CreateMap<UpdatePartyRoleDto, PartyRole>().ReverseMap();

		// Permission
		CreateMap<Permission, PermissionDto>().ReverseMap();
		CreateMap<CreatePermissionDto, Permission>().ReverseMap();
		CreateMap<UpdatePermissionDto, Permission>().ReverseMap();

		// PersonsInCompany
		CreateMap<PersonsInCompany, PersonsInCompanyDto>().ReverseMap();
		CreateMap<CreatePersonsInCompanyDto, PersonsInCompany>().ReverseMap();
		CreateMap<UpdatePersonsInCompanyDto, PersonsInCompany>().ReverseMap();

		// Attachment
		CreateMap<Attachment, AttachmentDto>().ReverseMap();
		CreateMap<CreateAttachmentDto, Attachment>().ReverseMap();
		CreateMap<UpdateAttachmentDto, Attachment>().ReverseMap();

		// AuditRecord
		CreateMap<AuditRecord, AuditRecordDto>().ReverseMap();
		CreateMap<CreateAuditRecordDto, AuditRecord>().ReverseMap();
		CreateMap<UpdateAuditRecordDto, AuditRecord>().ReverseMap();

		// Company
		CreateMap<Company, CompanyDto>().ReverseMap();
		CreateMap<CreateCompanyDto, Company>().ReverseMap();
		CreateMap<UpdateCompanyDto, Company>().ReverseMap();

		// ContractParty
		CreateMap<ContractParty, ContractPartyDto>().ReverseMap();
		CreateMap<CreateContractPartyDto, ContractParty>().ReverseMap();
		CreateMap<UpdateContractPartyDto, ContractParty>().ReverseMap();

		// ContractPartyInDocument
		CreateMap<ContractPartyInDocument, ContractPartyInDocumentDto>().ReverseMap();
		CreateMap<CreateContractPartyInDocumentDto, ContractPartyInDocument>().ReverseMap();
		CreateMap<UpdateContractPartyInDocumentDto, ContractPartyInDocument>().ReverseMap();

		// Document
		CreateMap<Document, DocumentDto>().ReverseMap();
		CreateMap<CreateDocumentDto, Document>().ReverseMap();
		CreateMap<UpdateDocumentDto, Document>().ReverseMap();

			//user
        CreateMap<User , UserDto>().ReverseMap();
			CreateMap<CreateUserDto, User>().ReverseMap();
			CreateMap<UpdateUserDto, User>().ReverseMap();



		}
	}
}
