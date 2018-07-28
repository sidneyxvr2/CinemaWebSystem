using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebSystem.Models
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendaId { get; set; }

        [Required]
        [Display(Name = "Cartão")]
        public int Cartao { get; set; }

        [Range(0, 4)]
        public int Meia { get; set; }

        [Range(0, 4)]
        public int Inteira { get; set; }

        [Display(Name = "Valor Total")]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Sessao")]
        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; }

        public ICollection<Ingresso> Ingressos { get; set; }
    }

    public class Cartao
    {
        public static Dictionary<int, string> Cartoes()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "Cartão Crédito");
            d.Add(2, "Cartão Débito");
            return d;
        }
    }
}