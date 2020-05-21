using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Psico.Models
{
    public class Escala
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Dia da Semana")]
        public int DiaDaSemana { get; set; }

        [DataType(DataType.Time)]
        public DateTime Inicio { get; set; }

        [DataType(DataType.Time)]
        public DateTime Fim { get; set; }

        public int DuracaoMinutos { get; set; }
    }
}
