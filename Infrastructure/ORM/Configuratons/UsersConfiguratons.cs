using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class UserConfigurations : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);  // المفتاح الأساسي

			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Name إلى 50

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Email إلى 50

			builder.Property(u => u.Password)
	   .HasMaxLength(255); // تحديد طول الحقل Password إلى 50

			builder.Property(u => u.Phone)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Phone إلى 50

			// إضافة علاقة مع المحرر (Editor)
			builder.HasOne(u => u.Editor)
				.WithMany()  // لا حاجة لعلاقة عكسية هنا في هذه الحالة
				.HasForeignKey(u => u.EditorId);  // المفتاح الخارجي EditorId

			// إضافة علاقة مع جدول UserRoles
			builder.HasMany(u => u.UserRoles)
				.WithOne(ur => ur.User)
				.HasForeignKey(ur => ur.UserId);  // المفتاح الخارجي UserId

			// إضافة علاقة مع جدول UserActivities
			builder.HasMany(u => u.UserActivities)
				.WithOne()
				.HasForeignKey(ua => ua.UserId);  // المفتاح الخارجي UserId في جدول الأنشطة
		}
	}

}
