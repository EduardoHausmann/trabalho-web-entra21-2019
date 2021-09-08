using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
