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
    public class UsuarioRepository : UsuarioInterface
    {
        SqlCommand cmd = Conexao.Conectar();

        public bool Alterar(Usuario usuario)
        {
            cmd.CommandText = @"UPDATE usuarios SET nome = @NOME, login = @LOGIN, senha = @SENHA WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", usuario.Id);
            cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
            cmd.Parameters.AddWithValue("@LOGIN", usuario.Login);
            cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada == true;
        }

        public bool Apagar(int id)
        {
            cmd.CommandText = @"DELETE FROM usuarios WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            bool qtdAfetada = Convert.ToBoolean(cmd.ExecuteNonQuery());
            cmd.Connection.Close();
            return qtdAfetada == true;
        }

        public int Inserir(Usuario usuario)
        {
            cmd.CommandText = @"INSERT INTO usuarios (nome, login, senha) OUTPUT INSERTED.ID VALUES (@NOME, @LOGIN, @SENHA)";
            cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
            cmd.Parameters.AddWithValue("@LOGIN", usuario.Login);
            cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);

            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return id;
        }

        public Usuario ObterPeloId(int id)
        {
            cmd.CommandText = @"SELECT * FROM usuarios WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", id);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();

            List<Usuario> usuarios = new List<Usuario>();
            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            Usuario usuario = new Usuario();
            usuario.Id = Convert.ToInt32(dr["id"]);
            usuario.Nome = dr["nome"].ToString();
            usuario.Login = dr["login"].ToString();
            usuario.Senha = dr["senha"].ToString();
            return usuario;
        }

        public List<Usuario> ObterTodos()
        {
            cmd.CommandText = @"SELECT * FROM usuarios";
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            List<Usuario> usuarios = new List<Usuario>();

            foreach (DataRow dr in dt.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.Id = Convert.ToInt32(dr["id"]);
                usuario.Nome = dr["nome"].ToString();
                usuario.Login = dr["login"].ToString();
                usuario.Senha = dr["senha"].ToString();
                usuarios.Add(usuario);
            }
            cmd.Connection.Close();
            return usuarios;
        }
    }
}
