using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TP06_multiF
{
    public class ProdutoDAL
    {
        public static string Inserir(Produto produto)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "INSERT INTO Produto (codigo, descricao, fornecedor, qtd_estoque, valor_unitario) " +
                             "VALUES (?, ?, ?, ?, ?)";

                OleDbCommand cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("?", produto.getCodigo());
                cmd.Parameters.AddWithValue("?", produto.getDescricao());
                cmd.Parameters.AddWithValue("?", produto.getFornecedor());
                cmd.Parameters.AddWithValue("?", int.Parse(produto.getQtdEstoque()));
                cmd.Parameters.AddWithValue("?", double.Parse(produto.getValorUnitario().Replace(",", ".")));

                cmd.ExecuteNonQuery();
                conn.Close();

                return "Produto cadastrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Produto Buscar(string codigo)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "SELECT * FROM Produto WHERE codigo = ?";

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", codigo);

                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Produto produto = new Produto();

                    produto.setCodigo(dr["codigo"].ToString());
                    produto.setDescricao(dr["descricao"].ToString());
                    produto.setFornecedor(dr["fornecedor"].ToString());
                    produto.setQtdEstoque(dr["qtd_estoque"].ToString());
                    produto.setValorUnitario(dr["valor_unitario"].ToString());

                    conn.Close();
                    return produto;
                }

                conn.Close();
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static List<string> ListarCodigos()
        {
            List<string> codigos = new List<string>();
            OleDbConnection conn = null;

            try
            {
                conn = ConexaoDAL.Conectar();
                string sql = "SELECT codigo FROM Produto";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    codigos.Add(dr["codigo"].ToString());
                }

                return codigos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return codigos; // retorna lista vazia em caso de erro
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static string Deletar(string codigo)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "DELETE FROM Produto WHERE codigo = ?";

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", codigo.Trim());

                int linhas = cmd.ExecuteNonQuery();

                conn.Close();

                if (linhas > 0)
                    return "Produto excluído com sucesso!";
                else
                    return "Produto não encontrado.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}