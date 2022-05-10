using Model;
using System.Collections.Generic;

namespace Interface
{
    public interface UsuarioInterface
    {
        int Inserir(Usuario usuario);

        bool Alterar(Usuario usuario);

        bool Apagar(int id);

        List<Usuario> ObterTodos();

        Usuario ObterPeloId(int id);
    }
}
