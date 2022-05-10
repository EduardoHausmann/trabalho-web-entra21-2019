using System.Data.SqlClient;

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
