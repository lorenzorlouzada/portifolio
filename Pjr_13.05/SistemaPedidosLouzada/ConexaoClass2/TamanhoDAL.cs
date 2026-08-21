using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexaoClass2
{
    public class TamanhoDAL
    {
        public List<TamanhoFoto> ListarTodos()
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                List<TamanhoFoto> lista = new List<TamanhoFoto>();
                string query = "SELECT * FROM TamanhosFoto ORDER BY preco";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TamanhoFoto
                    {
                        Id = (int)dr["id"],
                        Descricao = dr["descricao"].ToString(),
                        Preco = (decimal)dr["preco"]
                    });
                }
                return lista;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }
    }
}