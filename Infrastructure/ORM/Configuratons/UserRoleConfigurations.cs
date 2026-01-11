using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasKey(ur => ur.Id);  // المفتاح الأساسي

			builder.Property(ur => ur.UserId)
				.IsRequired();  // التأكد من أن UserId مطلوب

			builder.Property(ur => ur.RoleId)
				.IsRequired();  // التأكد من أن RoleId مطلوب

			// إضافة العلاقة مع جدول User
			builder.HasOne(ur => ur.User)
				.WithMany(u => u.UserRoles)
				.HasForeignKey(ur => ur.UserId);  // المفتاح الخارجي UserId

			// إضافة العلاقة مع جدول Role
			builder.HasOne(ur => ur.Role)
				.WithMany()
				.HasForeignKey(ur => ur.RoleId);  // المفتاح الخارجي RoleId

			// إضافة العلاقة مع المستخدم الذي قام بتعيين هذا الدور
			builder.HasOne(ur => ur.AssignedBy)
				.WithMany()
				.HasForeignKey(ur => ur.AssignedById)  // المفتاح الخارجي AssignedById
				.OnDelete(DeleteBehavior.Restrict);  // لا يمكن حذف المستخدم الذي قام بالتعيين إذا كانت هناك أدوار مرتبطة به
		}
	}

}
