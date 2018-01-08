using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyApp.Dtos;
using VidlyApp.Models;

namespace VidlyApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
		private ApplicationDbContext  _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET  /api/movies
		public IEnumerable<MovieDto> GetMovies() {
			return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
		}
		//GET /api/movies/id
		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault((m) => m.Id == id );
			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//POST /api/customer
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto moviedto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var movie = Mapper.Map<MovieDto, Movie>(moviedto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			moviedto.Id = movie.Id;
			return Created(new Uri( Request.RequestUri+"/"+ movie.Id), moviedto);
		}

		//PUT /api/movies/1
		[HttpPut]
		public void UpdateMovie(int id, MovieDto moviedto)
		{
			if (!ModelState.IsValid)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}

			var movieInDb = _context.Movies.SingleOrDefault((m) => m.Id == id);
			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			Mapper.Map<MovieDto, Movie>(moviedto, movieInDb);

			_context.SaveChanges();
		}

		//Delete  /api/movies/1
		[HttpDelete]
		public void DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault((m) => m.Id == id);
			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();
		}
    }
}
