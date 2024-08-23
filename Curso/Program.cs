using System;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      using var db = new Data.ApplicationContext();
      db.Database.Migrate();
      Console.WriteLine("Hello, World!");
    }
  }
}