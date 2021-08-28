using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Conexao
    {
        public static SqlCommand Conectar()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eduardo\Documents\GitHub\trabalho-web-entra21-2019\Trabalho_CSharp\Repository\Database.mdf;Integrated Security=True";
            cnx.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            return cmd;
        }
    }
}
