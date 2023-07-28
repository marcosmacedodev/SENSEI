namespace Sensei.Domain.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string CpfOuCnpj { get; set; }
        public string Tipo { get; set; }
        public List<string> Telefones { get; set; }
        public ICollection<PedidoDto> Pedidos { get; set; }
        public ICollection<EnderecoDto> Enderecos { get; set; }
    }
}