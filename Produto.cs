using System.Collections.Generic;
using System.IO;
using System;

namespace ManipulandoCsv
{
    public class Produto  : IProduto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/Produto.csv";

        public Produto(){

            string pasta = PATH.Split('/')[0];
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

         /// <summary>
        /// Reescreve uma linha nova
        /// </summary>
        /// <param name="linhas">Linha que utiliza o molde</param>
        public void ReescreverCSV(List<string> linhas){
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in linhas){
                    output.Write(ln+"\n");
                }
            }
        }

        /// <summary>
        /// Le as linhas que serao alteradas
        /// </summary>
        /// <param name="linhas">Linhas que usam o molde</param>
        /// <param name="_termo">Codigo, preço e nome</param>
        public void LerLinhas(List<string> linhas, string _termo){
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo));
            }
        }

        public void LerLinhas(List<string> linhas){
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }

            }
        }


        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="prod">Produto</param>
        public void Cadastrar(Produto prod){
            string[] linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Produto> Ler(){
            // Lista de produto
            List<Produto> produtos = new List<Produto>();

            // Linhas tranformadas em array de strings
            string[] linhas = File.ReadAllLines(PATH);

            // Varremos esse array de strings
            foreach (var linha in linhas){ 

                // Quebra de linha em partes
                string[] dados = linha.Split(";");

                // Tratamos e adicionamos dados em um novo produto
                Produto prod = new Produto();
                prod.Codigo = Int32.Parse( SepararDado(dados[0]));
                prod.Nome = SepararDado(dados[1]);
                prod.Preco = float.Parse(SepararDado(dados[2]));

                // Adicionado o produto antes de retorna-lo
                produtos.Add(prod);
            }
            return produtos;
            }


        public List<Produto> Filtrar(string _nome){
            return Ler().FindAll(x => x.Nome == _nome);
        }

        public void Remover(string _termo){
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo));
            }
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in linhas){
                    output.Write(ln+"\n");
                }
            }

        }


        public string SepararDado(string dados){
            return dados.Split("=")[1];
        }

         /// <summary>
        /// Altera o produto
        /// </summary>
        /// <param name="_produtoAlterado">Produto alterado</param>
        public void Alterar(Produto _produtoAlterado){
            List<string> linhas = new List<string>();
            LerLinhas(linhas);
            linhas.RemoveAll(r => r.Split(";")[0].Contains(_produtoAlterado.Codigo.ToString()));
            linhas.Add(PrepararLinha(_produtoAlterado));
            ReescreverCSV(linhas);
        }

        /// <summary>
        /// Molde de como as linhas sao criadas
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Molde</returns>

        

        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preço={p.Preco}";
        }
    }
}