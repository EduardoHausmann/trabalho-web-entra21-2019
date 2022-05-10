using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class ClienteRepository : ClienteInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
