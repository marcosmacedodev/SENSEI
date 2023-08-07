using AutoMapper;
using Sensei.Domain.Dtos;
using Sensei.Domain.Models;

namespace Sensei.App.SenseiMapper
{
    public class SenseiMapper: Profile
    {
        public SenseiMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Pagamento, PagamentoDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Cidade, CidadeDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }
}