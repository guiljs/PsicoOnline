using System.ComponentModel.DataAnnotations;

namespace Psico.Models
{
    public class TipoProfissional
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}