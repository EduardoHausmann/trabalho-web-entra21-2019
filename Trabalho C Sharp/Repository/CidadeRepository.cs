using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class CidadeRepository
    {
        public int Inserir(Cidade cidade)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO cidades (nome, id_estado, numero_habitantes) OUTPUT INSERTED.ID VALUES (@NOME, @ID_ESTADO, @NUMERO_HABITANTES)";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Cidade> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT cidades.id AS 'CidadeId',
cidades.nome AS 'CidadeNome',
cidades.numero_habitantes AS 'CidadeNumeroHabitantes',
cidades.id_estado AS 'CidadeIdEstado',
estados.nome AS 'EstadoNome'
FROM cidades
INNER JOIN estados ON (cidades.id_estado = estados.id);";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Cidade> cidades = new List<Cidade>();
            foreach (DataRow linha in tabela.Rows)
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt32(linha["CidadeId"]);
                cidade.Nome = linha["CidadeNome"].ToString();
                cidade.NumeroHabitantes = Convert.ToInt32(linha["CidadeNumeroHabitantes"]);
                cidade.Estado = new Estado();
                cidade.Estado.Nome = linha["EstadoNome"].ToString();
                cidades.Add(cidade);
            }
            return cidades;
        }

        public Cidade ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT cidades.id AS 'CidadeId',
cidades.nome AS 'CidadeNome',
cidades.numero_habitantes AS 'CidadeNumeroHabitantes',
cidades.id_estado AS 'CidadeIdEstado',
estados.nome AS 'EstadoNome'
FROM cidades
INNER JOIN estados ON (cidades.id_estado = estados.id)
WHERE cidades.id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Cidade> cidades = new List<Cidade>();
            if (tabela.Rows.Count == 0)
            {
                return null;
            }

            DataRow linha = tabela.Rows[0];
            Cidade cidade = new Cidade();
            cidade.Id = Convert.ToInt32(linha["CidadeId"]);
            cidade.Nome = linha["CidadeNome"].ToString();
            cidade.NumeroHabitantes = Convert.ToInt32(linha["CidadeNumeroHabitantes"]);
            cidade.Estado = new Estado();
            cidade.Estado.Nome = linha["EstadoNome"].ToString();
            return cidade;
        }

        public bool Alterar(Cidade cidade)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"UPDATE cidades SET nome = @NOME, numero_habitantes = @NUMERO_HABITANTES, id_estado = @ID_ESTADO WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", cidade.Id);
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);

            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"DELETE FROM cidades WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
