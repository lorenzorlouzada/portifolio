using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaClass;

namespace ConexaoClass
{
    public class ClienteDAL
    {
        public Cliente Login(string email, string senha)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                string query = "SELECT * FROM Clientes WHERE email = @email AND senha = @senha";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Cliente
                    {
                        Id = (int)dr["id"],
                        Nome = dr["nome"].ToString(),
                        Telefone = dr["telefone"].ToString(),
                        Email = dr["email"].ToString(),
                        Cep = dr["cep"].ToString(),
                        Rua = dr["rua"].ToString(),
                        Bairro = dr["bairro"].ToString(),
                        Cidade = dr["cidade"].ToString(),
                        Estado = dr["estado"].ToString(),
                        Perfil = dr["perfil"].ToString()
                    };
                }
                return null;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public bool Cadastrar(Cliente c)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                string query = @"INSERT INTO Clientes 
                    (nome, telefone, email, senha, cep, rua, bairro, cidade, estado, perfil)
                    VALUES (@nome, @telefone, @email, @senha, @cep, @rua, @bairro, @cidade, @estado, @perfil)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", c.Nome);
                cmd.Parameters.AddWithValue("@telefone", c.Telefone);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@senha", c.Senha);
                cmd.Parameters.AddWithValue("@cep", c.Cep);
                cmd.Parameters.AddWithValue("@rua", c.Rua);
                cmd.Parameters.AddWithValue("@bairro", c.Bairro);
                cmd.Parameters.AddWithValue("@cidade", c.Cidade);
                cmd.Parameters.AddWithValue("@estado", c.Estado);
                cmd.Parameters.AddWithValue("@perfil", c.Perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public List<Cliente> ListarTodos()
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                List<Cliente> lista = new List<Cliente>();
                string query = "SELECT * FROM Clientes WHERE perfil = 'cliente' ORDER BY nome";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = (int)dr["id"],
                        Nome = dr["nome"].ToString(),
                        Telefone = dr["telefone"].ToString(),
                        Email = dr["email"].ToString(),
                        Perfil = dr["perfil"].ToString()
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