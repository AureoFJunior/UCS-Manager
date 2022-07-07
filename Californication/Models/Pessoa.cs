using System.ComponentModel.DataAnnotations;

namespace Californication.Models
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }

    }
}