

using Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
		IUserRepository UserRepository { get; }
		IEditorRepository EditorRepository { get; }
		IDocumentRepository DocumentRepository { get; }
		IContractPartyRepository ContractPartyRepository { get; }
		ITemplateRepository TemplateRepository { get; }
		IAttachmentRepository AttachmentRepository { get; }
		IAuditRecordRepository AuditRecordRepository { get; }
		IFinancialTransactionRepository FinancialTransactionRepository { get; }
		INotificationRepository NotificationRepository { get; }
		IContractPartyInDocumentRepository ContractPartyInDocumentRepository { get; }
		ITemplateFieldRepository TemplateFieldRepository { get; }
		IIdentityRepository IdentityRepository { get; }
		ICompanyRepository CompanyRepository { get; }
		IPartyRoleRepository PartyRoleRepository { get; }
		IUserRoleRepository UserRoleRepository { get; }
		IRoleRepository RoleRepository { get; }
		IRolePermissionRepository RolePermissionRepository { get; }
		IPermissionRepository PermissionRepository { get; }
		IUserActivityRepository UserActivityRepository { get; }
		IPersonsInCompanyRepository PersonsInCompanyRepository { get; }

		Task<bool> Commit();
        Task<bool> HasChanges();
        Task Rollback();
    }
}
