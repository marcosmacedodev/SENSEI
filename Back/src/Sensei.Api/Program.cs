using Sensei.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Sensei.Persistence.Contracts;
using Sensei.Persistence.Services;
using Sensei.App.Contracts;
using Sensei.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IRepositoryCategoria, RepositoryCategoria>();
builder.Services.AddScoped<IRepositoryProduto, RepositoryProduto>();
builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
