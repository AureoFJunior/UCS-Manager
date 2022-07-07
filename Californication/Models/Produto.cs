using System.ComponentModel.DataAnnotations;

namespace Californication.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }

    }
}