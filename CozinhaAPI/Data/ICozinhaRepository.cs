using CozinhaAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozinhaAPI.Data
{
    public interface ICozinhaRepository
    {
        IEnumerable<Cozinha> GetAllCozinhas();
        Cozinha GetCozinhaById(int id);
        void CreateCozinha(Cozinha cozinha);
        void UpdateCozinha(Cozinha cozinha);
        void DeleteCozinha(Cozinha cozinha); 
    }
}
