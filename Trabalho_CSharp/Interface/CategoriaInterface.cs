using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface CategoriaInterface
    {
        int Inserir(Categoria categoria);

        bool Alterar(Categoria categoria);

        bool Apagar(int id);

        List<Categoria> ObterTodos();

        Categoria ObterPeloId(int id);
    }
}
