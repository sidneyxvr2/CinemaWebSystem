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
        public Cartao Cartao { get; set; }

        [Display(Name = "Valor Total")]
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

    public enum Cartao { Credito, Debito }
}