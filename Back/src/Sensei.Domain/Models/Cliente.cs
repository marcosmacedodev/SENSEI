using System.ComponentModel.DataAnnotations.Schema;
using Sensei.Domain.Enums;

namespace Sensei.Domain.Models
{
    [Table("clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string CpfOuCnpj { get; set; }
        public TipoCliente Tipo { get; set; } 
        //public ICollection<string> Telefones { get; set; } = new HashSet<string>();
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}