using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sensei.Domain.Models;

namespace Sensei.Persistence.DataContext
{
    public class Context: DbContext
    {
        private readonly IConfiguration _config;
        public Context(IConfiguration config){
            _config = config;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Pagamento TPH
            modelBuilder.Entity<Pagamento>()
            .HasDiscriminator<string>("PagamentoType")
            .HasValue<PagamentoComBoleto>("Boleto")
            .HasValue<PagamentoComCartao>("Cartao");
            //Tabela de associação entre Categoria e Produto (muitos para muitos)
            modelBuilder.Entity<CategoriaProduto>(
                opt => {
                    opt.HasKey(cp => new {cp.CategoriaId, cp.ProdutoId});
                    opt.HasOne<Categoria>(cp => cp.Categoria).WithMany(cat => cat.CategoriaProdutos).HasForeignKey(cp => cp.CategoriaId);
                    opt.HasOne<Produto>(cp => cp.Produto).WithMany(prod => prod.CategoriaProdutos).HasForeignKey(cp => cp.ProdutoId);
                }
            );
            //Tabela de associação entre Pedido e Produto (muitos para muitos)
            modelBuilder.Entity<ItemPedido>(
                opt => {
                    opt.HasKey(ip => new {ip.PedidoId, ip.ProdutoId});
                    opt.HasOne<Pedido>(ip => ip.Pedido).WithMany(ped => ped.ItensPedidos).HasForeignKey(ip => ip.PedidoId);
                    opt.HasOne<Produto>(ip => ip.Produto).WithMany(prod => prod.ItensPedidos).HasForeignKey(ip => ip.ProdutoId);
                }
            );
            //Associação entre Cliente e Pedido (um para muitos)
            modelBuilder.Entity<Cliente>(opt => {
                opt.HasMany<Pedido>(cli => cli.Pedidos)
                    .WithOne(peds => peds.Cliente)
                    .HasForeignKey(ped => ped.ClienteId);
                opt.HasMany<Endereco>(cli => cli.Enderecos)
                    .WithOne(end => end.Cliente)
                    .HasForeignKey(end => end.ClienteId);
                
            });
            //Associação entre Pedido e Endereco
            modelBuilder.Entity<Pedido>(opt => {
                opt.HasOne<Endereco>(ped => ped.Endereco)
                                        .WithOne()
                                        .HasForeignKey<Pedido>(ped => ped.EnderecoId);
                opt.HasOne<Pagamento>(ped => ped.Pagamento).WithOne(pag => pag.Pedido).HasForeignKey<Pagamento>(pag => pag.Id);
            });

            //Associação entre Endereco e Cidade
            modelBuilder.Entity<Endereco>().HasOne<Cidade>(end => end.Cidade).WithOne().HasForeignKey<Endereco>(end => end.CidadeId);
            //Associação entre Cidade e Estado
            modelBuilder.Entity<Estado>().HasMany<Cidade>(est => est.Cidades).WithOne(cid => cid.Estado).HasForeignKey(cid => cid.EstadoId);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = _config.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }

}