using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjetoRepository
    {
        public int Inserir(Projeto projeto)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"INSERT INTO projetos (nome, data_criacao, data_finalizacao, id_cliente) OUTPUT INSERTED.ID VALUES (@NOME, @DATA_CRIACAO, @DATA_FINALIZACAO, @ID_CLIENTE)";
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.Data_Criacao);
            comando.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.Data_Finalizacao);
            comando.Parameters.AddWithValue("ID_CLIENTE", projeto.Id_Cliente);
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();

            return id;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"DELETE FROM projetos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = (comando.ExecuteNonQuery());
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Alterar(Projeto projeto)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"UPDATE projetos SET id_cliente = @ID_CLIENTE, nome = @NOME, data_criacao = @DATA_CRIACAO, data_finalizacao = @DATA_FINALIZACAO WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID_CLIENTE", projeto.Id_Cliente);
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.Data_Criacao);
            comando.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.Data_Finalizacao);
            int quantidadeAfetada = Convert.ToInt32(comando.ExecuteNonQuery());
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public List<Projeto> ObterTodos()
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT projetos.id AS 'ProjetoId',
            projetos.id_cliente AS 'ProjetoIdCliente',
            projetos.nome AS 'ProjetoNome',
            projetos.data_criacao AS 'ProjetoDataCriacao',
            projetos.data_finalizacao AS 'ProjetoDataFinalizacao',
            clientes.Nome AS 'ClienteNome'
            FROM projetos
            INNER JOIN clientes ON (projetos.Id_Cliente = clientes.Id);";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Projeto> projetos = new List<Projeto>();
            foreach(DataRow linha in tabela.Rows)
            {
                Projeto projeto = new Projeto();
                projeto.Id_Cliente = Convert.ToInt32(linha["ProjetoIdCliente"]);
                projeto.Nome = linha["ProjetoNome"].ToString();
                projeto.Data_Criacao = Convert.ToDateTime(linha["ProjetoDataCriacao"]);
                projeto.Data_Finalizacao = Convert.ToDateTime(linha["ProjetoDatafinalizacao"]);
                projeto.Cliente = new Cliente();
                projeto.Cliente.Nome = linha["ClienteNome"].ToString();
                projetos.Add(projeto);
            }
            return projetos;
        }

        public Projeto ObterPeloId(int id)
        {
            SqlCommand comando = Conexao.Conectar();
            comando.CommandText = @"SELECT projeto.id AS 'ProjetoId',
            projeto.id_cliente AS 'ProjetoIdCliente',
            projeto.nome AS 'ProjetoNome',
            projeto.data_criacao AS 'ProjetoDataCriacao'
            projeto.data_finalizacao AS 'ProjetoDataFinalizacao'
            FROM projetos
            INNER JOIN clientes ON (projetos.id_cliente = cliente.id)
            WHERE id = @ID;";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<Projeto> projetos = new List<Projeto>();
            if(tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            Projeto projeto = new Projeto();
            projeto.Id_Cliente = Convert.ToInt32(linha["ProjetoIdCliente"]);
            projeto.Nome = linha["ProjetoNome"].ToString();
            projeto.Data_Criacao = Convert.ToDateTime(linha["ProjetoDataCriacao"]);
            projeto.Data_Finalizacao = Convert.ToDateTime(linha["ProjetoDataFinalizacao"]);
            projeto.Cliente = new Cliente();
            projeto.Cliente.Nome = linha["ClienteNome"].ToString();

            return projeto;
        }
    }
}
