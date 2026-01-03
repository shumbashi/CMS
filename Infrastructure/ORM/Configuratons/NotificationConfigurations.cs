using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
	{
		public void Configure(EntityTypeBuilder<Notification> builder)
		{
			builder.HasKey(n => n.Id);  // المفتاح الأساسي

			builder.Property(n => n.NotificationType)
				.HasMaxLength(50);

			builder.Property(n => n.NotificationTitle)
				.HasMaxLength(50);

			builder.Property(n => n.SendDate)
				.IsRequired();

			builder.Property(n => n.Content)
				.HasMaxLength(255);
		}
	}
	}
