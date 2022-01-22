using CozinhaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CozinhaAPI.Data
{
    public class CozinhaRepository : ICozinhaRepository
    {
        private readonly DbAcess _context;

        public CozinhaRepository(DbAcess context)
        {
            _context = context;
        }


        public IEnumerable<Cozinha> GetAllCozinhas()
        {
            return _context.Cozinha.Include(x => x.Ingrediente).ToList();
        }

        public Cozinha GetCozinhaById(int Id)
        {
            return _context.Cozinha.Include(x => x.Ingrediente).FirstOrDefault(c => c.Id == Id);
        }

        public void CreateCozinha(Cozinha cozinha)
        {
            if (cozinha == null) throw new ArgumentNullException(nameof(cozinha));

            _context.Cozinha.Add(cozinha);
            _context.SaveChanges();
        }

        public void UpdateCozinha(Cozinha cozinha)
        {
            _context.Update(cozinha);
            _context.SaveChanges();
        }

        public void DeleteCozinha(Cozinha cozinha)
        {
            if (cozinha == null) throw new ArgumentNullException(nameof(cozinha));

            _context.Remove(cozinha);
            _context.SaveChanges();
        }
    }
}
