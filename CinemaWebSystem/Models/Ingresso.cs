using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebSystem.Models
{
    public class Ingresso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngressoId { get; set; }

        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; }

        public int AssentoId { get; set; }
        public Assento Assento { get; set; }

        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        public bool Estudante { get; set; }
    }
}