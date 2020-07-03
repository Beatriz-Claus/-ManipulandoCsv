using System.Collections.Generic;
using System.IO;
using System;

namespace ManipulandoCsv
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/Produto.csv";

        public Produto(){
            // string pasta = PATH.Split('/')[0];
            // if(!Directory.Exists(pasta)){
            //     Directory.CreateDirectory(pasta);
            // }


            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        public void Cadastrar(Produto prod){
            string[] linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preço={p.Preco}";
        }
    }
}