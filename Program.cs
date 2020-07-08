  
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
            p1.Nome = "LG";
            p1.Nome = "Motorola";
            p1.Preco = 3900.99f;

             List<Produto> list = new List<Produto>();
            list = p1.Ler();

            foreach(Produto item in list){
                Console.ForegroundColor = ConsoleColor.Magenta;
                System.Console.WriteLine($"R$:{item.Preco} - {item.Nome}");
                Console.ResetColor();
            }

            p1.Cadastrar(p1);

           Produto alterado = new Produto();
            alterado.Codigo = 2;
            alterado.Nome = "Asus";
            alterado.Preco = 2500.99f;

             List<Produto> lista = p1.Ler();
            

            p1.Remover("LG");
        }
    }
}