using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : UsuarioInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Interir(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
