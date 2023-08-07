namespace Sensei.Domain.Models
{
    public class Telefone
    {
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}