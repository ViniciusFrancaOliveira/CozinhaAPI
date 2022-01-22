using CozinhaAPI.Model;
using System.Collections.Generic;

namespace CozinhaAPI.Data
{
    public interface IIngredienteRepository
    {
        IEnumerable<Ingrediente> GetAllIngredientes();
        Ingrediente GetIngredienteById(int id);
        void CreateIngrediente(Ingrediente ingrediente);
        void UpdateIngrediente(Ingrediente ingrediente);
        void DeleteIngrediente(Ingrediente ingrediente);
    }
}