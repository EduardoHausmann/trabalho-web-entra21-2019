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
    public class CidadeRepository : CidadeInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Cidade cidade)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Interir(Cidade cidade)
        {
            throw new NotImplementedException();
        }

        public Cidade ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cidade> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
