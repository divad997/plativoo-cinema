using CinemaApi.Interfaces;
using CinemaCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGenre = await _genreService.CreateGenreAsync(genre);

            return CreatedAtAction("GetGenreById", new { id = newGenre.Id }, newGenre);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genres = await _genreService.GetAllGenresAsync();

            if (genres == null)
            {
                return NotFound();
            }

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = await _genreService.GetGenreByIdAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> EditGenre([FromBody] Genre genre)
        {
            if (await _genreService.EditGenreAsync(genre) == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _genreService.DeleteGenreAsync(id) == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
