using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.IdentityDTO
{
	public class UpdateIdentityDto
	{
		public Guid Id { get; set; }
		public IdentityType IdentityType { get; set; }
		public string? NationalNumber { get; set; }
		public string? ResidenceNumber { get; set; }
		public string? AdministrativeNumber { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Nationality { get; set; }
		public string PhoneNumber { get; set; }
		public string IdentityProof { get; set; }
		public Guid UserId { get; set; }
	}
}
