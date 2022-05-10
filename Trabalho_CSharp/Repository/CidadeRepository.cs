using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class CidadeRepository : CidadeInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Cidade cidade)
        {
            cmd.CommandText = @"UPDATE cidades SET id_estado = @ESTADO, nome = @NOME, numero_habitantes = @HABITANTES WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", cidade.Id);
            cmd.Parameters.AddWithValue("@ESTADO", cidade.IdEstado);
            cmd.Parameters.AddWithValue("@NOME", cidade.Nome);
            cmd.Parameters.AddWithValue("@HABITANTES", cidade.NumeroHabitante);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada == true;
        }

        public bool Apagar(int id)
        {
            cmd.CommandText = @"DELETE FROM cidades WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada == true;
        }

        public int Inserir(Cidade cidade)
        {
            cmd.CommandText = @"INSERT INTO cidades (id_estado, nome, numero_habitantes) OUTPUT INSERTED.ID VALUES (@ESTADO, @NOME, @HABITANTES)";
            cmd.Parameters.AddWithValue("@ESTADO", cidade.IdEstado);
            cmd.Parameters.AddWithValue("@NOME", cidade.Nome);
            cmd.Parameters.AddWithValue("@HABITANTES", cidade.NumeroHabitante);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public Cidade ObterPeloId(int id)
        {
            cmd.CommandText = @"SELECT cidades.id AS 'CidadeId',
cidades.nome AS 'CidadeNome',
cidades.numero_habitantes AS 'CidadeHabitantes',
cidades.id_estado AS 'CidadeIdEstado',
estados.nome AS 'EstadoNome'
FROM cidades
INNER JOIN estados ON (cidades.id_estado = estados.id)
WHERE cidades.id = @ID";

            cmd.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();

            List<Cidade> cidades = new List<Cidade>();
            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            Cidade cidade = new Cidade();
            cidade.Id = Convert.ToInt32(dr["CidadeId"]);
            cidade.Nome = dr["CidadeNome"].ToString();
            cidade.NumeroHabitante = Convert.ToInt32(dr["CidadeHabitantes"]);
            cidade.Estado = new Estado();
            cidade.Estado.Nome = dr["EstadoNome"].ToString();
            return cidade;
        }

        public List<Cidade> ObterTodos()
        {
            cmd.CommandText = @"SELECT cidades.id AS 'CidadeId',
cidades.nome AS 'CidadeNome',
cidades.numero_habitantes AS 'CidadeHabitantes',
cidades.id_estado AS 'CidadeIdEstado',
estados.nome AS 'EstadoNome'
FROM cidades
INNER JOIN estados ON (cidades.id_estado = estados.id)";

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            List<Cidade> cidades = new List<Cidade>();
            foreach (DataRow dr in dt.Rows)
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt32(dr["CidadeId"]);
                cidade.Nome = dr["CidadeNome"].ToString();
                cidade.NumeroHabitante = Convert.ToInt32(dr["CidadeHabitantes"]);
                cidade.Estado = new Estado();
                cidade.Estado.Nome = dr["EstadoNome"].ToString();
                cidades.Add(cidade);
            }
            cmd.Connection.Close();
            return cidades;
        }
    }
}
