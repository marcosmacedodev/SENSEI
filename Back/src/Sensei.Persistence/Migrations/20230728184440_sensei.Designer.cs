﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sensei.Persistence.DataContext;

#nullable disable

namespace Sensei.Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230728184440_sensei")]
    partial class sensei
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sensei.Domain.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("Sensei.Domain.Models.CategoriaProduto", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CategoriaProdutos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("cidades");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CpfOuCnpj")
                        .HasColumnType("longtext");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId")
                        .IsUnique();

                    b.HasIndex("ClienteId");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("Sensei.Domain.Models.ItemPedido", b =>
                {
                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double>("Desconto")
                        .HasColumnType("double");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("itenspedidos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Pagamento", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("PagamentoType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("pagamentos");

                    b.HasDiscriminator<string>("PagamentoType").HasValue("Pagamento");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Sensei.Domain.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Nome")
                        .HasColumnType("int");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.PagamentoComBoleto", b =>
                {
                    b.HasBaseType("Sensei.Domain.Models.Pagamento");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.ToTable("pagamentos");

                    b.HasDiscriminator().HasValue("Boleto");
                });

            modelBuilder.Entity("Sensei.Domain.Models.PagamentoComCartao", b =>
                {
                    b.HasBaseType("Sensei.Domain.Models.Pagamento");

                    b.Property<int>("NumeroDeParcelas")
                        .HasColumnType("int");

                    b.ToTable("pagamentos");

                    b.HasDiscriminator().HasValue("Cartao");
                });

            modelBuilder.Entity("Sensei.Domain.Models.CategoriaProduto", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Categoria", "Categoria")
                        .WithMany("CategoriaProdutos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sensei.Domain.Models.Produto", "Produto")
                        .WithMany("CategoriaProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Cidade", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Endereco", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Cidade", "Cidade")
                        .WithOne()
                        .HasForeignKey("Sensei.Domain.Models.Endereco", "CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sensei.Domain.Models.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Sensei.Domain.Models.ItemPedido", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Pedido", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sensei.Domain.Models.Produto", "Produto")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Pagamento", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Pedido", "Pedido")
                        .WithOne("Pagamento")
                        .HasForeignKey("Sensei.Domain.Models.Pagamento", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Pedido", b =>
                {
                    b.HasOne("Sensei.Domain.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sensei.Domain.Models.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("Sensei.Domain.Models.Pedido", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Categoria", b =>
                {
                    b.Navigation("CategoriaProdutos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Cliente", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Pedido", b =>
                {
                    b.Navigation("ItensPedidos");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("Sensei.Domain.Models.Produto", b =>
                {
                    b.Navigation("CategoriaProdutos");

                    b.Navigation("ItensPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}