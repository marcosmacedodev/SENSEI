namespace Sensei.Domain.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}