using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
	public enum IdentityType
	{
		undefinde = 0,
		Citizen, //مواطن
		Resident , //مقيم
		AdministrativeNumber // مواطن بدون رقم وطني،ولديه رقم إداري
	}
}
