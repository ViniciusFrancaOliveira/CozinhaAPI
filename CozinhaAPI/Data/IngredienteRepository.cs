using CozinhaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CozinhaAPI.Data
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly DbAcess _context;

        public IngredienteRepository(DbAcess context)
        {
            _context = context;
        }

        public IEnumerable<Ingrediente> GetAllIngredientes()
        {
            return _context.Ingrediente.ToList();
        }

        public Ingrediente GetIngredienteById(int id)
        {
            return _context.Ingrediente.FirstOrDefault(x => x.Id == id);
        }

        public void CreateIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null) throw new ArgumentNullException(nameof(ingrediente));

            _context.Ingrediente.Add(ingrediente);
            _context.SaveChanges();
        }

        public void DeleteIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null) throw new ArgumentNullException(nameof(ingrediente));

            _context.Remove(ingrediente);
            _context.SaveChanges();
        }

        public void UpdateIngrediente(Ingrediente ingrediente)
        {
            _context.Update(ingrediente);
            _context.SaveChanges();
        }
    }
}