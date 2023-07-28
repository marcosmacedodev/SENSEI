using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensei.Domain.Dtos
{
    public class EstadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<CidadeDto> Cidades { get; set; }
    }
}