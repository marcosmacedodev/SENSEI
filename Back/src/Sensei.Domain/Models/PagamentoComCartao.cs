namespace Sensei.Domain.Models
{
    public class PagamentoComCartao: Pagamento
    {
        public int NumeroDeParcelas { get; set; }
    }
}