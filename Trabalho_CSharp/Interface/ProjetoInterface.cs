using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
