using System;
using System.Data.SqlClient;

namespace ConexaoClass
{
    public class Conexao
    {
        private static string stringConexao =
            "Server=localhost\\SQLEXPRESS;Database=SistemaPedidosLouzada;Trusted_Connection=True;";

        public static SqlConnection ObterConexao()
        {
            SqlConnection con = new SqlConnection(stringConexao);
            con.Open();
            return con;
        }

        public static void FecharConexao(SqlConnection con)
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}