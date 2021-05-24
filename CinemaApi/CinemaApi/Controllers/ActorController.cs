using CinemaApi.Interfaces;
using CinemaCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newActor = await _actorService.CreateActorAsync(actor);

            return CreatedAtAction("GetActorById", new { id = newActor.Id }, newActor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actors = await _actorService.GetAllActorsAsync();

            if (actors == null)
            {
                return NotFound();
            }

            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = await _actorService.GetActorByIdAsync(id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> EditActor([FromBody] Actor actor)
        {
            if (await _actorService.EditActorAsync(actor) == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _actorService.DeleteActorAsync(id) == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
