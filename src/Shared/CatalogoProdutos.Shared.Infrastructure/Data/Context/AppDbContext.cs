﻿using Microsoft.EntityFrameworkCore;
using CatalogoProdutos.Shared.Domain.Entities;

namespace CatalogoProdutos.Shared.Infrastructure.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 6);
    }
}