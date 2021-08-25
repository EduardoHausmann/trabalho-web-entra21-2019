using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface TarefaInterface
    {
        int Interir(Tarefa tarefa);

        bool Alterar(Tarefa tarefa);

        bool Apagar(int id);

        List<Tarefa> ObterTodos();

        Tarefa ObterPeloId(int id);
    }
}
