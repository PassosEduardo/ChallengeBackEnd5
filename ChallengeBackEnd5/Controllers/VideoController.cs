using ChallengeBackEnd5.Data.DTOs;
using ChallengeBackEnd5.Models;
using ChallengeBackEnd5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBackEnd5.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VideoController : ControllerBase
    {
        public videoRepo _repository;

        public VideoController(videoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetVideoFromQuery([FromQuery] string? search = null)
        {
            if (search == null)
            {
                var result = _repository.GetAll();

                if (result.Count == 0)
                    return NoContent();

                return Ok(result);
            }
            else
            {
                var result = _repository.GetVideoFromQuery(search);
                if (result.Count == 0)
                    return NoContent();

                return Ok(result);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _repository.GetById(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostVideo([FromBody] CreateVideoDTO videoDTO)
        { 
            var result = _repository.PostVideo(videoDTO);

            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchVideo([FromRoute] int id,[FromBody] PatchVideoDTO videoDTO)
        {
            var result = _repository.PatchVideo(id, videoDTO);

            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideo([FromRoute] int id)
        {
            var result = _repository.DeleteVideo(id);

            if(result is Video)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
    }
}
