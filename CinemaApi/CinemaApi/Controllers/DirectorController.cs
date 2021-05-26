using CinemaApi.Interfaces;
using CinemaCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDirector = await _directorService.CreateDirectorAsync(director);

            return CreatedAtAction("GetDirectorById", new { id = newDirector.Id }, newDirector);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var directors = await _directorService.GetAllDirectorsAsync();

            if (directors == null)
            {
                return NotFound();
            }

            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirectorById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = await _directorService.GetDirectorByIdAsync(id);

            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        [HttpPut]
        public async Task<IActionResult> EditDirector([FromBody] Director director)
        {
            if (await _directorService.EditDirectorAsync(director) == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _directorService.DeleteDirectorAsync(id) == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
