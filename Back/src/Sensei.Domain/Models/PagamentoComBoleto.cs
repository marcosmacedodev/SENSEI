namespace Sensei.Domain.Models
{
    public class PagamentoComBoleto: Pagamento
    {
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}