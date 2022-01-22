using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CozinhaAPI.Model;
using CozinhaAPI.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace CozinhaAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteRepository _repository;

        public IngredienteController(IIngredienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult GetAllIngredientes()
        {
            IEnumerable<Ingrediente> ingredientes = _repository.GetAllIngredientes();

            return Ok(ingredientes);
        }

        [HttpGet("{id}", Name = "GetIngredienteById")]
        public ActionResult GetIngredienteById(int id)
        {
            Ingrediente ingrediente = _repository.GetIngredienteById(id);

            if (ingrediente == null) return NotFound();

            return Ok(ingrediente); 
        }

        [HttpPost]
        public ActionResult CreateIngrediente([FromBody] Ingrediente ingrediente)
        {
            _repository.CreateIngrediente(ingrediente);

            return CreatedAtRoute("GetIngredienteById", new { Id = ingrediente.Id }, ingrediente);
        }


        [HttpPatch("{id}")]
        public ActionResult<Ingrediente> UpdateCozinha(JsonPatchDocument<Ingrediente> patchDocument, int id)
        {
            Ingrediente ingrediente = _repository.GetIngredienteById(id);
            if (ingrediente == null) return NotFound();

            patchDocument.ApplyTo(ingrediente, ModelState);
            if (!TryValidateModel(ingrediente)) return ValidationProblem(ModelState);

            _repository.UpdateIngrediente(ingrediente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCozinha(int id)
        {
            Ingrediente ingrediente = _repository.GetIngredienteById(id);
            if (ingrediente == null) return NotFound();

            _repository.DeleteIngrediente(ingrediente);

            return NoContent();
        }
    }
}
