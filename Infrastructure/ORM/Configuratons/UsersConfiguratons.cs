using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class UserConfigurations : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			// تعيين المفتاح الأساسي
			builder.HasKey(u => u.Id);  // استخدام `Id` من `BaseEntity` كـ Primary Key

			// تخصيص الأعمدة الخاصة بـ User إذا لزم الأمر
			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Name إلى 50

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Email إلى 50

			builder.Property(u => u.Password)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Password إلى 50

			builder.Property(u => u.Phone)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Phone إلى 50

			builder.Property(u => u.NationalNumber)
				.IsRequired();  // الرقم الوطني يجب أن يكون مطلوبًا

			// يمكن تخصيص المزيد من الأعمدة بناءً على احتياجاتك
		}
	}
}
