using Interface;
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
    public class CategoriaRepository : CategoriaInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Categoria categoria)
        {
            cmd.CommandText = @"UPDATE categorias SET nome = @NOME WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", categoria.Id);
            cmd.Parameters.AddWithValue("@NOME", categoria.Nome);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada = true;
        }

        public bool Apagar(int id)
        {
            cmd.CommandText = @"DELETE FROM categorias WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada = true;
        }

        public int Interir(Categoria categoria)
        {
            cmd.CommandText = @"INSERT INTO categorias (nome) OUTPUT INSERTED.ID VALUES (@NOME)";
            cmd.Parameters.AddWithValue("@NOME", categoria.Nome);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public Categoria ObterPeloId(int id)
        {
            cmd.CommandText = @"SELECT * FROM categorias WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();

            List<Categoria> categorias = new List<Categoria>();
            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            Categoria categoria = new Categoria();
            categoria.Id = Convert.ToInt32(dr["id"]);
            categoria.Nome = dr["nome"].ToString();
            return categoria;
        }

        public List<Categoria> ObterTodos()
        {
            cmd.CommandText = @"SELECT * FROM categorias";
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            List<Categoria> categorias = new List<Categoria>();

            foreach (DataRow dr in dt.Rows)
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(dr["id"]);
                categoria.Nome = dr["nome"].ToString();
                categorias.Add(categoria);
            }
            cmd.Connection.Close();
            return categorias;
        }
    }
}
