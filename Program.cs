  
using System;
using System.Collections.Generic;

namespace  ManipulandoCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Samsung Galaxy A20";
            p1.Preco = 3900.99f;

            p1.Cadastrar(p1);
        }
    }
}