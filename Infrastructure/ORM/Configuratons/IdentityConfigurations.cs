using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class IdentityConfigurations : IEntityTypeConfiguration<Identity>
	{
		public void Configure(EntityTypeBuilder<Identity> builder)
		{
			builder.HasKey(i => i.Id);  // المفتاح الأساسي من `BaseEntity`
		

			// تخصيص الحقول القابلة لأن تكون NULL مثل NationalNumber و AdministrativeNumber
			builder.Property(i => i.NationalNumber)
				.HasMaxLength(12)
				.IsRequired(false);  // الرقم الوطني ليس إلزاميًا حسب `IdentityType`، سيبقى `nullable` (NULL)

			builder.Property(i => i.AdministrativeNumber)
				.HasMaxLength(12)
				.IsRequired(false);  // الرقم الإداري ليس إلزاميًا، وبالتالي يبقى `nullable` (NULL)

			builder.Property(i => i.BirthDate)
				.IsRequired();  // تاريخ الميلاد مطلوب

			builder.Property(i => i.Nationality)
				.HasMaxLength(50);  // تحديد طول الجنسية

			builder.Property(i => i.PhoneNumber)
				.IsRequired()
				.HasMaxLength(12);  // تحديد طول رقم الهاتف

			builder.Property(i => i.IdentityProof)
				.HasMaxLength(12);  // تحديد طول إثبات الهوية

			// العلاقة مع المستخدم (User)
			builder.HasOne(i => i.User)
				.WithMany(u => u.Identities)  // علاقة Many-to-One مع User (مستخدم واحد يمكن أن يكون له عدة هويات)
				.HasForeignKey(i => i.UserId)  // المفتاح الخارجي UserId
				.IsRequired();  // العلاقة مطلوبة

			// العلاقة مع المحرر (Editor)
			builder.HasMany(e => e.Editors)
				.WithOne(i => i.Identity)
				.HasForeignKey(i => i.IdentityId)
				.IsRequired();  // العلاقة مع المحرر

			// العلاقة مع الأطراف (ContractParty)
			builder.HasMany(i => i.ContractParties)
				.WithOne(cp => cp.Identity)
				.HasForeignKey(cp => cp.IdentityId)
				.IsRequired();  // العلاقة مع الأطراف

			// العلاقة مع الأشخاص في الشركات (PersonsInCompany)
			builder.HasMany(i => i.PersonsInCompanies)
				.WithOne(p => p.Identity)
				.HasForeignKey(p => p.IdentityId)
				.IsRequired();  // العلاقة مع الأشخاص في الشركات



			// إضافة الفهرسة للأعمدة
			builder.HasIndex(i => i.NationalNumber)
				.HasDatabaseName("UQ_NationalNumber")
				.IsUnique(true);  // فهرسة الرقم الوطني ليكون فريدًا

			builder.HasIndex(i => i.AdministrativeNumber)
				.HasDatabaseName("UQ_AdministrativeNumber")
				.IsUnique(true);  // فهرسة الرقم الإداري ليكون فريدًا

			builder.HasIndex(i => i.PhoneNumber)
				.HasDatabaseName("UQ_PhoneNumber")
				.IsUnique(true);  // فهرسة رقم الهاتف ليكون ف
		}
	}



}
