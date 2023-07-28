using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensei.Domain.Dtos
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
        public int CidadeId { get; set; }
        public CidadeDto Cidade { get; set; }
    }
}