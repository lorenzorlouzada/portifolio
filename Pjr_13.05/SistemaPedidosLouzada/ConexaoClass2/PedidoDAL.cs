using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConexaoClass2
{
    public class PedidoDAL
    {
        public bool CriarPedido(Pedido pedido)
        {
            SqlConnection con = Conexao.ObterConexao();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                string queryPedido = @"INSERT INTO Pedidos (codigoPedido, status, observacao, id_cliente)
                              OUTPUT INSERTED.id
                              VALUES (@codigo, @status, @obs, @idCliente)";
                SqlCommand cmd = new SqlCommand(queryPedido, con, trans);
                cmd.Parameters.AddWithValue("@codigo", pedido.CodigoPedido);
                cmd.Parameters.AddWithValue("@status", "Aguardando");
                cmd.Parameters.AddWithValue("@obs", pedido.Observacao ?? "");
                cmd.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
                int idPedido = (int)cmd.ExecuteScalar();

                foreach (var item in pedido.Itens)
                {
                    string queryItem = @"INSERT INTO ItensPedido 
                                (quantidade, observacao, id_pedido, id_produto, id_tamanho)
                                VALUES (@qtd, @obs, @idPedido, @idProduto, @idTamanho)";
                    SqlCommand cmdItem = new SqlCommand(queryItem, con, trans);
                    cmdItem.Parameters.AddWithValue("@qtd", item.Quantidade);
                    cmdItem.Parameters.AddWithValue("@obs", item.Observacao ?? "");
                    cmdItem.Parameters.AddWithValue("@idPedido", idPedido);
                    cmdItem.Parameters.AddWithValue("@idProduto", item.IdProduto);
                    cmdItem.Parameters.AddWithValue("@idTamanho",
                        item.IdTamanho.HasValue ? (object)item.IdTamanho.Value : DBNull.Value);
                    cmdItem.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public List<Pedido> ListarTodos()
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                List<Pedido> lista = new List<Pedido>();
                string query = @"SELECT p.*, c.nome as nomeCliente, c.telefone as telefoneCliente
                                FROM Pedidos p
                                INNER JOIN Clientes c ON p.id_cliente = c.id
                                ORDER BY p.dataPedido DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Pedido
                    {
                        Id = (int)dr["id"],
                        CodigoPedido = dr["codigoPedido"].ToString(),
                        DataPedido = (DateTime)dr["dataPedido"],
                        Status = dr["status"].ToString(),
                        Observacao = dr["observacao"].ToString(),
                        IdCliente = (int)dr["id_cliente"],
                        NomeCliente = dr["nomeCliente"].ToString(),
                        TelefoneCliente = dr["telefoneCliente"].ToString()
                    });
                }
                return lista;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public bool AtualizarStatus(int idPedido, string novoStatus)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                string query = "UPDATE Pedidos SET status = @status WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@status", novoStatus);
                cmd.Parameters.AddWithValue("@id", idPedido);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                Conexao.FecharConexao(con);
            }
        }

        public List<ItemPedido> ListarItensPorPedido(int idPedido)
        {
            SqlConnection con = Conexao.ObterConexao();
            try
            {
                List<ItemPedido> lista = new List<ItemPedido>();
                string query = @"SELECT ip.*, p.nome as nomeProduto
                        FROM ItensPedido ip
                        INNER JOIN Produtos p ON ip.id_produto = p.id
                        WHERE ip.id_pedido = @idPedido";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ItemPedido
                    {
                        Id = (int)dr["id"],
                        NomeProduto = dr["nomeProduto"].ToString(),
                        Quantidade = (int)dr["quantidade"],
                        Observacao = dr["observacao"].ToString()
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