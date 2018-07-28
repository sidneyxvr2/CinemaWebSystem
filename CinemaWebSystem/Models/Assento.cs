using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebSystem.Models
{
    public class Assento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssentoId { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [RegularExpression(@"[a-zA-Z]+")]
        public string Fila { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        
        [Required]
        [Display(Name = "Sala")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        public Ativa Ativa { get; set; } = Ativa.Sim;

        public ICollection<Ingresso> Ingressos { get; set; }
    }
}