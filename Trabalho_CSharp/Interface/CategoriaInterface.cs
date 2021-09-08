using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
