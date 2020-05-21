using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Psico.Models
{
    public class Profissional
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Description = "Número do conselho")]
        public string Conselho { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Biografia { get; set; }

        [Display(Name ="Tipo")]
        public TipoProfissional TipoProfissional { get; set; }

    }
}
