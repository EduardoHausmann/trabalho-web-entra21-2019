using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface ProjetoInterface
    {
        int Inserir(Projeto projeto);

        bool Alterar(Projeto projeto);

        bool Apagar(int id);

        List<Projeto> ObterTodos();

        Projeto ObterPeloId(int id);
    }
}
