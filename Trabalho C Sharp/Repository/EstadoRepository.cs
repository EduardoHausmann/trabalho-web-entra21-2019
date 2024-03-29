﻿using System;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Repository
{
    public class EstadoRepository
    {

        public int Inserir(Estado estado)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO estados (nome,sigla) OUTPUT INSERTED.ID VALUES(@NOME,@SIGLA)";
            comando.Parameters.AddWithValue("@NOME", estado.Nome);
            comando.Parameters.AddWithValue("@SIGLA", estado.Sigla);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Estado> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT * FROM estados";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            List<Estado> estados = new List<Estado>();
            foreach (DataRow linha in tabela.Rows)
            {
                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(linha["id"]);
                estado.Nome = linha["nome"].ToString();
                estado.Sigla = linha["sigla"].ToString();
                estados.Add(estado);
            }
            comando.Connection.Close();
            return estados;
        }

        public Estado ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT * FROM estados WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];
            Estado estado = new Estado();
            estado.Id = Convert.ToInt32(linha["id"]);
            estado.Nome = linha["nome"].ToString();
            estado.Sigla = linha["sigla"].ToString();
            return estado;
        }

        public bool Alterar(Estado estado)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"UPDATE estados SET nome = @NOME, sigla= @SIGLA WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", estado.Id);
            comando.Parameters.AddWithValue("@NOME", estado.Nome);
            comando.Parameters.AddWithValue("@SIGLA", estado.Sigla);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"DELETE FROM estados WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}

