using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSystem.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Required]
        [Display(Name = "Nome completo")]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha", ErrorMessage = "As Senha Não Correspondem")]
        [Display(Name = "Confirme sua Senha")]
        [DataType(DataType.Password)]
        public string SenhaCofirmada { get; set; }

        public bool Estudante { get; set; }

        public Ativa Ativa { get; set; } = Ativa.Sim;

        public virtual ICollection<Venda> Vendas { get; set; }
    }

    public class Estudante
    {
        public static Dictionary<bool, string> Estudantes ()
        {
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(false, "Não");
            d.Add(true, "Sim");
            return d;
        }
    }
}
