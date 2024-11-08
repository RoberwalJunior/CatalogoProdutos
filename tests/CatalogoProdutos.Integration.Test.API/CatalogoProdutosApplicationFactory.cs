﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using CatalogoProdutos.Shared.Infrastructure.Data.Context;
using CatalogoProdutos.Shared.Domain.Entities;

namespace CatalogoProdutos.Integration.Test.API;

public class CatalogoProdutosApplicationFactory : WebApplicationFactory<Program>
{
    private readonly AppDbContext _context;

    public CatalogoProdutosApplicationFactory()
    {
        var scope = Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    public async Task<Produto> RecuperarUmProdutoJaCadastrado()
    {
        var produtoExistente = _context.Produtos.FirstOrDefault();

        if (produtoExistente == null)
        {
            var vendedorExistente = await RecuperarUmVendedorJaCadastrado();
            var novoProduto = new Produto()
            {
                VendedorId = vendedorExistente.Id,
                Codigo = 1000,
                Nome = "Produto para teste de API",
                Descricao = "Produto para teste de API",
                Quantidade = 10,
                Valor = 10,
                DataCadastrado = DateTime.Now,
                DataAtualizado = DateTime.Now.AddDays(15)
            };

            await _context.Produtos.AddAsync(novoProduto);
            await _context.SaveChangesAsync();

            produtoExistente = novoProduto;
        }

        return produtoExistente;
    }

    public async Task<Vendedor> RecuperarUmVendedorJaCadastrado()
    {
        var vendedorExistente = _context.Vendedores.FirstOrDefault();

        if (vendedorExistente == null)
        {
            var novoVendedor = new Vendedor()
            {
                Nome = "Vendedor de Teste"
            };

            await _context.Vendedores.AddAsync(novoVendedor);
            await _context.SaveChangesAsync();

            vendedorExistente = novoVendedor;
        }

        return vendedorExistente;
    }
}
