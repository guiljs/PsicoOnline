using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Psico.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Paciente")]
        public IdentityUser Cliente_ID { get; set; }

        [Display(Name ="Profissinal")]
        public Profissional Profissional_ID { get; set; }

        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        [Display(Name ="Preço")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        public bool Autorizado { get; set; }

        public bool? Cancelado { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
