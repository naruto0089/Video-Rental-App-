
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
	public class MembershipType
	{
		public int Id { get; set; }

		[Required]
		[Display(Name ="Membership Type")]
		public string MembershipTypeName { get; set; }

		[Required]
		public decimal SignUpFee { get; set; }

		[Required]
		public byte DurationInMonths { get; set; }

		[Required]
		public decimal DiscountRate { get; set; }


	}
}