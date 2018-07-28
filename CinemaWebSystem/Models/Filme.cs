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
        [StringLength(60, MinimumLength = 1)]
        public string Titulo { get; set; }

        public byte[] Imagem { get; set; }

        [Required]
        [Display(Name = "Classificação Indicativa")]
        public int Classificacao { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public Ativa Ativa { get; set; } = Ativa.Sim;

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }

    public class Classificacao
    {
        public static Dictionary<int, string> Classificacoes()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(0, "Livre Para Todos os Públicos");
            d.Add(10, "Não Recomendade Para Menores de 10 Anos");
            d.Add(12, "Não Recomendade Para Menores de 12 Anos");
            d.Add(14, "Não Recomendade Para Menores de 14 Anos");
            d.Add(16, "Não Recomendade Para Menores de 16 Anos");
            d.Add(18, "Não Recomendade Para Menores de 18 Anos");
            return d;
        }

        public static Dictionary<int, string> ClassificacaoImagens()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(0, "/images/livre.png");
            d.Add(10, "/images/10.png");
            d.Add(12, "/images/12.png");
            d.Add(14, "/images/14.png");
            d.Add(16, "/images/16.png");
            d.Add(18, "/images/18.png");
            return d;
        }
    }
}
