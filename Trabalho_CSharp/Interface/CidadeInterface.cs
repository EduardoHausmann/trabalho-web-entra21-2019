using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
