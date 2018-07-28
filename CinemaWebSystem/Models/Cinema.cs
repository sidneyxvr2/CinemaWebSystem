using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebSystem.Models
{
    public class Cinema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaId { get; set; }

        [Required]
        [Display(Name = "Cinema")]
        [StringLength(50, MinimumLength = 1)]
        public string Nome { get; set; }

        [DataType(DataType.PostalCode)]
        //[RegularExpression(@"^[0-9]{2}\.[0-9]{3}\-[0-9]{3}$")]
        public string Cep { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(50, MinimumLength = 3)]
        public string Bairro { get; set; }

        [Display(Name = "Rua")]
        [StringLength(50, MinimumLength = 3)]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        public Ativa Ativa { get; set; } = Ativa.Sim;

        public virtual ICollection<Sala> Salas { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }

    public class Estados
    {
        public static Dictionary<int, string> SiglaEstados()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "AC");
            d.Add(2, "AL");
            d.Add(3, "AM");
            d.Add(4, "AP");
            d.Add(5, "BA");
            d.Add(6, "CE");
            d.Add(7, "DF");
            d.Add(8, "ES");
            d.Add(9, "GO");
            d.Add(10, "MA");
            d.Add(11, "MG");
            d.Add(12, "MS");
            d.Add(13, "MT");
            d.Add(14, "PA");
            d.Add(15, "PB");
            d.Add(16, "PE");
            d.Add(17, "PI");
            d.Add(18, "PR");
            d.Add(19, "RJ");
            d.Add(20, "RN");
            d.Add(21, "RO");
            d.Add(22, "RR");
            d.Add(23, "RS");
            d.Add(24, "SC");
            d.Add(25, "SE");
            d.Add(26, "SP");
            d.Add(27, "TO");
            return d;
        }           
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
