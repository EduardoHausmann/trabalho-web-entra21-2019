using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface CidadeInterface
    {
        int Inserir(Cidade cidade);

        bool Alterar(Cidade cidade);

        bool Apagar(int id);

        List<Cidade> ObterTodos();

        Cidade ObterPeloId(int id);
    }
}
