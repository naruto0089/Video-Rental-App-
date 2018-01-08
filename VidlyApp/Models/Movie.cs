using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }


		public Genre Genre { get; set; }
		public int GenreId { get; set; }

		[Required]
		[Display(Name ="Release Date")]
		
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }
	}
}