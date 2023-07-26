using System.ComponentModel.DataAnnotations.Schema;
using Sensei.Domain.Enums;

namespace Sensei.Domain.Models
{
    [Table("pagamentos")]
    public class Pagamento
    {
        public int Id { get; set; }
        public EstadoPagamento Estado { get; set; }
    }
}