using System.Collections.Generic;

namespace ManipulandoCsv
{
    public interface IProduto
    {

        
        // Metodo CRUD
        ///<returns>E herdado pelo Produto</returns>
         List<Produto> Ler();
         void Cadastrar(Produto prod);
         void Remover(string _termo);
         void Alterar(Produto _produtoAlterado);
    }
}