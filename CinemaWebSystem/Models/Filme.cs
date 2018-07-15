using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSystem.Models
{
    public class Filme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmeId { get; set; }

        [Required]
        [Display(Name = "Título")]
        [StringLength(25, MinimumLength = 1)]
        public string Titulo { get; set; }

        public byte[] Imagem { get; set; }

        [Required]
        [Display(Name = "Classificação Indicativa")]
        public Classificacao Classificacao { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }

    public enum Classificacao
    {
        [Description("Livre Para Todos os Públicos")]
        Livre = 99,
        
        [Description("Não Recomendado Para Menores de 10 Anos de Idade")]
        Dez = 10,

        [Description("Não Recomendado Para Menores de 12 Anos de Idade")]
        Doze = 12,

        [Description("Não Recomendado Para Menores de 14 Anos de Idade")]
        Quartoze = 14,

        [Description("Não Recomendado Para Menores de 16 Anos de Idade")]
        Dezesseis = 16,

        [Description("Não Recomendado Para Menores de 18 Anos de Idade")]
        Dezesoito = 18,
    }
}
