﻿using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjetoRepository : ProjetoInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public Projeto ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Projeto> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
