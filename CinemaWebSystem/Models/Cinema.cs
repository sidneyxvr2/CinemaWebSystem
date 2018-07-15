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

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Estado { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Cidade { get; set; }

        [Display(Name = "Localização")]
        [StringLength(50, MinimumLength = 5)]
        public string Localizacao { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
    }
}
