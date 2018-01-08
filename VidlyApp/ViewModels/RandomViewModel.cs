using System.Collections.Generic;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
	public class RandomViewModel
	{
		public Movie Movies { get; set; }
		public List<Customer> Customers { get; set; }
	}
}