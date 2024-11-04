using Microsoft.EntityFrameworkCore;
using CatalogoProdutos.Shared.Infrastructure.Data.Context;
using CatalogoProdutos.Shared.Domain.Interfaces.Repositories;
using CatalogoProdutos.Shared.Infrastructure.Data.Repositories;
using CatalogoProdutos.Shared.Domain.Interfaces.Services;
using CatalogoProdutos.Shared.Domain.Services;
using CatalogoProdutos.Shared.Application.Interfaces;
using CatalogoProdutos.Shared.Application.ServiceApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IVendedorService, VendedorService>();

builder.Services.AddTransient<IProdutoServiceApp, ProdutoServiceApp>();
builder.Services.AddTransient<IVendedorServiceApp, VendedorServiceApp>();
builder.Services.AddTransient<IEstoqueServiceApp, EstoqueServiceApp>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
