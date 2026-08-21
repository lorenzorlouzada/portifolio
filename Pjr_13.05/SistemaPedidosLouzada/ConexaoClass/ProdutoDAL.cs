using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaClass;

namespace ConexaoClass
{
    public class ProdutoDAL
    {
        public List<Produto> ListarTodos()
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                List<Produto> lista = new List<Produto>();
                string query = @"SELECT p.*, c.nome as nomeCategoria 
                                FROM Produtos p 
                                INNER JOIN Categorias c ON p.id_categoria = c.id
                                WHERE p.ativo = 1
                                ORDER BY c.nome, p.nome";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Produto
                    {
                        Id = (int)dr["id"],
                        Nome = dr["nome"].ToString(),
                        Descricao = dr["descricao"].ToString(),
                        Preco = (decimal)dr["preco"],
                        TemFoto = (bool)dr["temFoto"],
                        IdCategoria = (int)dr["id_categoria"],
                        NomeCategoria = dr["nomeCategoria"].ToString()
                    });
                }
                return lista;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public bool Cadastrar(Produto p)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                string query = @"INSERT INTO Produtos (nome, descricao, preco, temFoto, id_categoria)
                                VALUES (@nome, @descricao, @preco, @temFoto, @idCategoria)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@descricao", p.Descricao ?? "");
                cmd.Parameters.AddWithValue("@preco", p.Preco);
                cmd.Parameters.AddWithValue("@temFoto", p.TemFoto);
                cmd.Parameters.AddWithValue("@idCategoria", p.IdCategoria);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public bool Excluir(int id)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                string query = "UPDATE Produtos SET ativo = 0 WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }
    }
}