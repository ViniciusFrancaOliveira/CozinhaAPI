using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozinhaAPI.Model
{
    public class Ingrediente
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataDeValidade { get; set; }

        public int CozinhaId { get; set; }
    }
}
