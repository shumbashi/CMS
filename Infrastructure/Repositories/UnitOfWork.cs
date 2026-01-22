using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Interfaces.Repository;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using Infrastructure.Repositories.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ServiceDbContext _dbContext;
		private readonly IPasswordHasher _passwordHasher;

		// إضافة المستودعات هنا

		public UnitOfWork(ServiceDbContext dbContext)
		{
			_dbContext = dbContext;
			_passwordHasher = new BCryptPasswordHasher();

			// Initialize Repositories
			UserRepository = new UserRepository(_dbContext);
			EditorRepository = new EditorRepository(_dbContext);
			DocumentRepository = new DocumentRepository(_dbContext);
			ContractPartyRepository = new ContractPartyRepository(_dbContext);
			TemplateRepository = new TemplateRepository(_dbContext);
			AttachmentRepository = new AttachmentRepository(_dbContext);
			AuditRecordRepository = new AuditRecordRepository(_dbContext);
			FinancialTransactionRepository = new FinancialTransactionRepository(_dbContext);
			NotificationRepository = new NotificationRepository(_dbContext);
			ContractPartyInDocumentRepository = new ContractPartyInDocumentRepository(_dbContext);
			TemplateFieldRepository = new TemplateFieldRepository(_dbContext);
			IdentityRepository = new IdentityRepository(_dbContext);
			CompanyRepository = new CompanyRepository(_dbContext);
			PartyRoleRepository = new PartyRoleRepository(_dbContext);
			UserRoleRepository = new UserRoleRepository(_dbContext);
			RoleRepository = new RoleRepository(_dbContext);
			RolePermissionRepository = new RolePermissionRepository(_dbContext);
			PermissionRepository = new PermissionRepository(_dbContext);
			UserActivityRepository = new UserActivityRepository(_dbContext);
			PersonsInCompanyRepository = new PersonsInCompanyRepository(_dbContext);
		}

		public IUserRepository UserRepository { get; }
		public IEditorRepository EditorRepository { get; }
		public IDocumentRepository DocumentRepository { get; }
		public IContractPartyRepository ContractPartyRepository { get; }
		public ITemplateRepository TemplateRepository { get; }
		public IAttachmentRepository AttachmentRepository { get; }
		public IAuditRecordRepository AuditRecordRepository { get; }
		public IFinancialTransactionRepository FinancialTransactionRepository { get; }
		public INotificationRepository NotificationRepository { get; }
		public IContractPartyInDocumentRepository ContractPartyInDocumentRepository { get; }
		public ITemplateFieldRepository TemplateFieldRepository { get; }
		public IIdentityRepository IdentityRepository { get; }
		public ICompanyRepository CompanyRepository { get; }
		public IPartyRoleRepository PartyRoleRepository { get; }
		public IUserRoleRepository UserRoleRepository { get; }
		public IRoleRepository RoleRepository { get; }
		public IRolePermissionRepository RolePermissionRepository { get; }
		public IPermissionRepository PermissionRepository { get; }
		public IUserActivityRepository UserActivityRepository { get; }
		public IPersonsInCompanyRepository PersonsInCompanyRepository { get; }

		// لحفظ التغييرات في قاعدة البيانات
		public async Task<bool> Commit()
		{
			try
			{
				var success = await _dbContext.SaveChangesAsync() > 0;
				return success;
			}
			catch (Exception ex)
			{
				// يمكن التعامل مع الاستثناءات هنا
				throw new Exception("An error occurred while saving changes.", ex);
			}
		}

		// التحقق إذا كانت هناك تغييرات
		public Task<bool> HasChanges()
		{
			var hasChanges = _dbContext.ChangeTracker.HasChanges();
			return Task.FromResult(hasChanges);
		}

		// Rollback التراجع عن التغييرات
		public Task Rollback()
		{
			try
			{
				// إعادة تحميل الكائنات من الذاكرة وإلغاء التغييرات
				_dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while rolling back changes.", ex);
			}
		}
	}
}
