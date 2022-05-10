using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class EstadoRepository : EstadoInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Estado estado)
        {
            cmd.CommandText = @"UPDATE estados SET nome = @NOME, sigla = @SIGLA WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", estado.Id);
            cmd.Parameters.AddWithValue("@NOME", estado.Nome);
            cmd.Parameters.AddWithValue("@SIGLA", estado.Sigla);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada = true;
        }

        public bool Apagar(int id)
        {
            cmd.CommandText = @"DELETE FROM estados WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada = true;
        }

        public int Inserir(Estado estado)
        {
            cmd.CommandText = @"INSERT INTO estados (nome, sigla) OUTPUT INSERTED.ID VALUES (@NOME , @SIGLA)";
            cmd.Parameters.AddWithValue("@NOME", estado.Nome);
            cmd.Parameters.AddWithValue("@SIGLA", estado.Sigla);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public Estado ObterPeloId(int id)
        {
            cmd.CommandText = @"SELECT * FROM estados WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();

            List<Estado> estados = new List<Estado>();
            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            Estado estado = new Estado();
            estado.Id = Convert.ToInt32(dr["id"]);
            estado.Nome = dr["nome"].ToString();
            estado.Sigla = dr["sigla"].ToString();
            return estado;
        }

        public List<Estado> ObterTodos()
        {
            cmd.CommandText = @"SELECT * FROM estados";
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            List<Estado> estados = new List<Estado>();

            foreach (DataRow dr in dt.Rows)
            {
                Estado estado = new Estado();
                estado.Id = Convert.ToInt32(dr["id"]);
                estado.Nome = dr["nome"].ToString();
                estado.Sigla = dr["sigla"].ToString();
                estados.Add(estado);
            }
            cmd.Connection.Close();
            return estados;
        }
    }
}
