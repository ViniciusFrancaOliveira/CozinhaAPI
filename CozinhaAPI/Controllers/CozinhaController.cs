using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CozinhaAPI.Model;
using CozinhaAPI.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace CozinhaAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CozinhaController : ControllerBase
    {
        private readonly ICozinhaRepository _repository;

        public CozinhaController(ICozinhaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cozinha>> GetAllCozinhas()
        {
            IEnumerable<Cozinha> cozinhaItems = _repository.GetAllCozinhas();

            return Ok(cozinhaItems);
        }

        [HttpGet("{id}", Name = "GetCozinhaById")]
        public ActionResult<Cozinha> GetCozinhaById(int id)
        {
            Cozinha cozinhaItem = _repository.GetCozinhaById(id);

            if (cozinhaItem == null) return NotFound();

            return Ok(cozinhaItem);
        }

        [HttpPost]
        public ActionResult<Cozinha> CreateCozinha([FromBody] Cozinha cozinha)
        {
            _repository.CreateCozinha(cozinha);

            return CreatedAtRoute(nameof(GetCozinhaById), new { Id = cozinha.Id }, cozinha);
        }

        [HttpPatch("{id}")]
        public ActionResult<Cozinha> UpdateCozinha(JsonPatchDocument<Cozinha> patchDocument, int id)
        {
            Cozinha cozinha = _repository.GetCozinhaById(id);
            if (cozinha == null) return NotFound();

            patchDocument.ApplyTo(cozinha, ModelState);
            if (!TryValidateModel(cozinha)) return ValidationProblem(ModelState);

            _repository.UpdateCozinha(cozinha);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCozinha(int id)
        {
            Cozinha cozinha = _repository.GetCozinhaById(id);
            if (cozinha == null) return NotFound();

            _repository.DeleteCozinha(cozinha);

            return NoContent();

        }
    }
}
