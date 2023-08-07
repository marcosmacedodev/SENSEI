using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sensei.Domain.Models;

namespace Sensei.Persistence.DataContext
{
    public class SenseiContext: DbContext
    {
        private readonly IConfiguration _config;
        public SenseiContext(IConfiguration config){
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
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>().HasKey(tel => new {tel.ClienteId, tel.Numero});
            modelBuilder.Entity<CategoriaProduto>().HasKey(cp => new { cp.CategoriaId,  cp.ProdutoId});
            modelBuilder.Entity<ItemPedido>().HasKey(ip => new { ip.PedidoId, ip.ProdutoId});
            modelBuilder.Entity<Pagamento>(opt => {
                opt.HasKey(pg => pg.PedidoId);
                opt.HasDiscriminator<string>("tipo_pagamento")
                .HasValue<PagamentoComBoleto>("boleto")
                .HasValue<PagamentoComCartao>("cartao");
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = _config.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }

}