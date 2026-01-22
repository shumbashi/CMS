
using Domain.Common;
using Domain.Entities;
using Infrastructure.ORM.EFConverters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.ORM
{
    public class ServiceDbContext : DbContext 
    {
      
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {

			

        }
		public DbSet<User> Users { get; set; }  // جدول المستخدمين
		public DbSet<Editor> Editors { get; set; }  // جدول المحررين
		public DbSet<Document> Documents { get; set; }  // جدول الوثائق
		public DbSet<ContractParty> ContractParties { get; set; }  // جدول الأطراف
		public DbSet<Template> Templates { get; set; }  // جدول القوالب
		public DbSet<Attachment> Attachments { get; set; }  // جدول المرفقات
		public DbSet<AuditRecord> AuditRecords { get; set; }  // جدول سجلات التدقيق
		public DbSet<FinancialTransaction> FinancialTransactions { get; set; }  // جدول المعاملات المالية
		public DbSet<Notification> Notifications { get; set; }  // جدول التنبيهات
		public DbSet<ContractPartyInDocument> ContractPartyInDocuments { get; set; }  // جدول الأطراف في الوثائق
		public DbSet<TemplateField> TemplateFields { get; set; }  // جدول حقول القالب
		public DbSet<Identity> Identities { get; set; }  
		public DbSet<Company> Companies { get; set; }  
		public DbSet<PartyRole> PartyRoles { get; set; }  
		public DbSet<UserRole> UserRoles { get; set; }  
		public DbSet<Role> Roles { get; set; }  
		public DbSet<RolePermission> RolePermissions { get; set; }  
		public DbSet<Permission> Permissions { get; set; }  
		public DbSet<UserActivity> UserActivities { get; set; }  
		public DbSet<PersonsInCompany> PersonsInCompanies { get; set; }  




		public override int SaveChanges(/*CancellationToken cancellationToken = new CancellationToken()*/)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow.AddHours(2);
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow.AddHours(2);
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow.AddHours(2);
                        break;
                }
            }
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow.AddHours(2);
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow.AddHours(2);
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.UtcNow.AddHours(2);
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<decimal>()
                .HaveColumnType("decimal(15,3)");

            builder.Properties<decimal?>()
                .HaveColumnType("decimal(15,3)");

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConvert>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConvert>()
                .HaveColumnType("datetime2");
            

            builder.Properties<TimeOnly?>()
                .HaveConversion<NullableTimeOnlyConverter>()
                .HaveColumnType("datetime2");
        }


    }
}

