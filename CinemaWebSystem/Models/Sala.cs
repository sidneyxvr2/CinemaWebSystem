using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSystem.Models
{
    public class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaId { get; set; }

        [Required]
        [Display(Name = "Sala")]
        [StringLength(20, MinimumLength = 1)]
        public string Nome { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Quantidade de Assentos")]
        public int QuantidadeAssentos { get; set; }

        public Ativa Ativa { get; set; } = Ativa.Sim;

        [Required]
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public ICollection<Assento> Assentos { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }
    }

    public enum Ativa { Sim, Nao };
}
