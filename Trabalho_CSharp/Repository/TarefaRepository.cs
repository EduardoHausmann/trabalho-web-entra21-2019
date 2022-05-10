using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class TarefaRepository : TarefaInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Tarefa ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
