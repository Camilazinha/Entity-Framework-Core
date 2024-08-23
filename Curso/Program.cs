using System;
using System.Linq;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      using var db = new Data.ApplicationContext();

      // db.Database.Migrate();
      var existe = db.Database.GetPendingMigrations().Any();

      if (existe)
      {
        //
      }

      Console.WriteLine("Hello, World!");
    }

    private static void InserirDados()
    {
      var produto = new Produto
      {
        Descricao = "Produto Teste",
        CodigoBarras = "1234567891231",
        Valor = 10m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };

      using var db = new Data.ApplicationContext();
      // db.Produtos.Add(produto);
      // db.Set<Produto>().Add(produto); 
      // db.Entry(produto).State = EntityState.Added;
      db.Add(produto);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total Registros(s): {registros}");
    }
  }
}