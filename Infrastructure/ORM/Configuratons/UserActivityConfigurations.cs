using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class UserActivityConfigurations : IEntityTypeConfiguration<UserActivity>
	{
		public void Configure(EntityTypeBuilder<UserActivity> builder)
		{

			builder.HasKey(ua => ua.Id);  // المفتاح الأساسي

			builder.HasOne(ua => ua.User)
				.WithMany(u => u.UserActivities)
				.HasForeignKey(ua => ua.UserId)  // المفتاح الخارجي UserId
				.OnDelete(DeleteBehavior.Cascade);  // إذا كان المستخدم محذوفًا، يتم حذف الأنشطة المرتبطة به

			builder.Property(ua => ua.Activity)
				.IsRequired()
				.HasMaxLength(100);  // تحديد طول الحقل Activity إلى 100

			builder.Property(ua => ua.Date)
				.IsRequired();  // تاريخ النشاط مطلوب
		}
	}

}
