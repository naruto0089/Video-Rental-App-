using System.Web.Mvc;
using VidlyApp.Models;
using System.Data.Entity;
using System.Linq;
using VidlyApp.ViewModels;

namespace VidlyApp.Controllers
{
	public class MoviesController: Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		
		public ActionResult Index()
		{
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			return View(movie);
		}

		public ActionResult AddMovies()
		{
			var genre = _context.Genres.ToList();
			var genreViewModel = new MovieViewModel
			{
				Movie = new Movie(),
				Genre = genre
			};
			ViewBag.Title = "Add Movie";
			return View(genreViewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieViewModel
			{
				Movie = movie,
				Genre = _context.Genres.ToList()
			};
			ViewBag.Title = "Edit Movie";

			return View("AddMovies", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid) {
				var viewModel = new MovieViewModel
				{
					Movie = movie,
					Genre = _context.Genres.ToList()
				};
				return View("AddMovies", viewModel);
			}
			if(movie.Id == 0)
				_context.Movies.Add(movie);
			else
			{
				var moviesInDB = _context.Movies.Single(m => m.Id == movie.Id);
				moviesInDB.Name = movie.Name;
				moviesInDB.GenreId = movie.GenreId;
				moviesInDB.ReleaseDate = movie.ReleaseDate;
				moviesInDB.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
		}
	}
}