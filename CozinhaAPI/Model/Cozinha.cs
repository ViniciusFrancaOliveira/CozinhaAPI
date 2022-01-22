using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CozinhaAPI.Model
{
    [Index(nameof(NomeDaCozinha), IsUnique = true)]
    public class Cozinha
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string NomeDaCozinha { get; set; }

        [Required]
        public int HoraDeAbertura { get; set; }

        [Required]
        public int HoraDeFechamento { get; set; }

        [Required]
        [MaxLength(50)]
        public string PratoPrincipal { get; set; }

        public List<Ingrediente> Ingrediente { get; set; }
    }
}
