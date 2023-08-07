using Sensei.Domain.Enums;

namespace Sensei.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CpfOuCnpj { get; set; }
        public TipoCliente Tipo { get; set; } 
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}