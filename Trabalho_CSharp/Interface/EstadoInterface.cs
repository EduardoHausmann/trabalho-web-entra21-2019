using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface EstadoInterface
    {
        int Inserir(Estado estado);

        bool Alterar(Estado estado);

        bool Apagar(int id);

        List<Estado> ObterTodos();

        Estado ObterPeloId(int id);
    }
}
