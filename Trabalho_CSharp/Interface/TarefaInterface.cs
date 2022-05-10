using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface TarefaInterface
    {
        int Inserir(Tarefa tarefa);

        bool Alterar(Tarefa tarefa);

        bool Apagar(int id);

        List<Tarefa> ObterTodos();

        Tarefa ObterPeloId(int id);
    }
}
