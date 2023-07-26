using System.ComponentModel.DataAnnotations.Schema;
using Sensei.Domain.Enums;

namespace Sensei.Domain.Models
{
    [Table("clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CpfOuCnpj { get; set; }
        public TipoCliente Tipo { get; set; }
        public List<string> Telefones { get; set; } = new List<string>();
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}