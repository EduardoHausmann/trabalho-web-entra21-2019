using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface ClienteInterface
    {
        int Inserir(Cliente cliente);

        bool Alterar(Cliente cliente);

        bool Apagar(int id);

        List<Cliente> ObterTodos();

        Cliente ObterPeloId(int id);
    }
}
