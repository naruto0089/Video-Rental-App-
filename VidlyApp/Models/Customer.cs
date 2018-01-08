using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{

	public class Customer
	{
		public int Id { get; set; }

		[Required]
		public String Name { get; set; }

		[Required]
		public bool IsSuscribedToNewsLetter { get; set; }

		[Display(Name = "Birth Date")]
		public DateTime? BirthDate { get; set; }


		public MembershipType MembershipType { get; set; }
		public int MembershipTypeId { get; set; }


	}
}