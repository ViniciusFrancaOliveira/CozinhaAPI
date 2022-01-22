using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CozinhaAPI.Model;

namespace CozinhaAPI.Data
{
    public class DbAcess : DbContext
    {
        public DbAcess(DbContextOptions<DbAcess> opt) : base(opt) { }

        public DbSet<Cozinha> Cozinha { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
    }
}
