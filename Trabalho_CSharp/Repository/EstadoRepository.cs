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
    public class EstadoRepository : EstadoInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Estado estado)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Interir(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Estado ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Estado> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
