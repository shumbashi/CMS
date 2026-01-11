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

			// تحديد خصائص الـ NationalNumber و PhoneNumber كـ NOT NULL
			builder.Property(i => i.NationalNumber)
				.IsRequired();  // الرقم الوطني مطلوب

			builder.Property(i => i.BirthDate)
				.IsRequired();  // تاريخ الميلاد مطلوب

			builder.Property(i => i.NationalId)
				.HasMaxLength(50);  // تحديد طول الرقم التجاري إذا لزم الأمر

			builder.Property(i => i.Nationality)
				.HasMaxLength(50);  // تحديد طول الجنسية

			builder.Property(i => i.PhoneNumber)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول رقم الهاتف إلى 50

			builder.Property(i => i.IdentityProof)
				.HasMaxLength(100);  // تحديد طول إثبات الهوية

			// العلاقة مع المستخدم (User)
			builder.HasOne(i => i.User)
				.WithMany(u => u.Identities)  // علاقة Many-to-One مع User (مستخدم واحد يمكن أن يكون له عدة هويات)
				.HasForeignKey(i => i.UserId)  // المفتاح الخارجي UserId
				.IsRequired();  // العلاقة مطلوبة

			// تخصيص العلاقة بين الـ Identity و User في حالة وجود خصائص إضافية قد تحتاج إلى تفعيلها
		}
	}


}
