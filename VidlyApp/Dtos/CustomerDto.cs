using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApp.Dtos
{
	public class CustomerDto
	{
		public int Id { get; set; }

		[Required]
		public String Name { get; set; }

		[Required]
		public bool IsSuscribedToNewsLetter { get; set; }

		
		public DateTime? BirthDate { get; set; }

		public int MembershipTypeId { get; set; }
	}
}