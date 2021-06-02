using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CinemaApi.Interfaces;
using CinemaCore.Models;
using CinemaApi.Dtos;

namespace movieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMovie = await _movieService.CreateMovieAsync(movieDto);

            return CreatedAtAction("GetMovieById", new { id = newMovie.Id }, newMovie);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movies = await _movieService.GetAllMoviesAsync();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut]
        public async Task<IActionResult> EditMovie([FromBody] MovieDto movieDto)
        {
            if (await _movieService.EditMovieAsync(movieDto) == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _movieService.DeleteMovieAsync(id) == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
