using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.IdentityDTO
{
	public class CreateIdentityDto
	{
		public IdentityType IdentityType { get; set; }  // نوع الهوية
		public string? NationalNumber { get; set; }  // رقم الهوية الوطني
		public string? ResidenceNumber { get; set; }  // رقم الإقامة
		public string? AdministrativeNumber { get; set; }  // رقم إداري
		public DateTime? BirthDate { get; set; }  // تاريخ الميلاد
		public string Nationality { get; set; }  // الجنسية
		public string PhoneNumber { get; set; }  // رقم الهاتف
		public string IdentityProof { get; set; }  // إثبات الهوية
		public Guid UserId { get; set; }  // معرف المستخدم
	}
}
