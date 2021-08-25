using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface UsuarioInterface
    {
        int Interir(Usuario usuario);

        bool Alterar(Usuario usuario);

        bool Apagar(int id);

        List<Usuario> ObterTodos();

        Usuario ObterPeloId(int id);
    }
}
