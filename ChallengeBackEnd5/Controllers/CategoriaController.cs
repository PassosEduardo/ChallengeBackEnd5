using ChallengeBackEnd5.Data.DTOs.Categoria;
using ChallengeBackEnd5.Models;
using ChallengeBackEnd5.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBackEnd5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public categoryRepo _repository;

        public CategoriaController(categoryRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll();

            if(result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] int id)
        {
            var result = _repository.GetById(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoriaDTO categoriaDTO)
        {
            var result = _repository.Post(categoriaDTO);

            if(result is Categoria)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute]int id,[FromBody] PatchCategoriaDTO categoriaDTO)
        {
            var result = _repository.Patch(id, categoriaDTO);

            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _repository.Delete(id);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("{id}/videos")]
        public IActionResult GetVideoByCategory([FromRoute]int id)
        {
            var result = _repository.GetVideoByCategory(id);

            if(result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
