using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Identity : BaseEntity, IAggregateRoot
	{
		public IdentityType IdentityType { get; set; }

		public string? NationalNumber { get; set; }       // مواطن
		public string? ResidenceNumber { get; set; }      // مقيم
		public string? AdministrativeNumber { get; set; } // مواطن بدون رقم وطني

		public DateTime? BirthDate { get; set; }
		public string Nationality { get; set; }
		public string PhoneNumber { get; set; }
		public string IdentityProof { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }

		public ICollection<Editor> Editors { get; set; }  // علاقة مع المحررين
		public ICollection<ContractParty> ContractParties { get; set; }  // علاقة مع الأطراف
		public ICollection<PersonsInCompany> PersonsInCompanies { get; set; }  // علاقة مع الشخاص في الشركة

		/*// 👇 القاعدة الذهبية
		public void Validate()
		{
			if (IdentityType == IdentityType.Citizen)
			{
				if (string.IsNullOrWhiteSpace(NationalNumber) &&
					string.IsNullOrWhiteSpace(AdministrativeNumber))
				{
					throw new DomainException(
						"المواطن لازم يكون عنده رقم وطني أو رقم إداري");
				}

				if (!string.IsNullOrWhiteSpace(ResidenceNumber))
				{
					throw new DomainException(
						"المواطن ما يكونش عنده رقم إقامة");
				}
			}

			if (IdentityType == IdentityType.Resident)
			{
				if (string.IsNullOrWhiteSpace(ResidenceNumber))
				{
					throw new DomainException(
						"المقيم لازم يكون عنده رقم إقامة");
				}

				if (!string.IsNullOrWhiteSpace(NationalNumber) ||
					!string.IsNullOrWhiteSpace(AdministrativeNumber))
				{
					throw new DomainException(
						"المقيم ما يكونش عنده رقم وطني أو إداري");
				}
			}*/
	}
	}

