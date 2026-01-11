using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Identity : BaseEntity , IAggregateRoot
    {
		public int NationalNumber { get; set; }  // الرقم الوطني
		public DateTime BirthDate { get; set; }  // تاريخ الميلاد
		public string NationalId { get; set; }  // الرقم التجاري
		public string Nationality { get; set; }  // الجنسية
		public string PhoneNumber { get; set; }  // رقم الهاتف (NOT NULL)
		public string IdentityProof { get; set; }  // إثبات الهوية
		public Guid UserId { get; set; }  // مفتاح خارجي يشير إلى المستخدم

		public User User { get; set; }                                       // العلاقة مع الأدوار (Many-to-Many عبر UserRole)

	}
}
