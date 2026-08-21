using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP06_multiF
{
    public class AlunoDAL
    {
        public static string Inserir(Aluno aluno)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "INSERT INTO Aluno (ra, nome, sexo, data_nascimento, telefone) " +
                             "VALUES (@ra, @nome, @sexo, @data, @telefone)";

                OleDbCommand cmd = new OleDbCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ra", aluno.getRA());
                cmd.Parameters.AddWithValue("@nome", aluno.getNome());
                cmd.Parameters.AddWithValue("@sexo", aluno.getSexo());
                cmd.Parameters.AddWithValue("@data", aluno.getDataNasc());
                cmd.Parameters.AddWithValue("@telefone", aluno.getTelefone());

                cmd.ExecuteNonQuery();
                conn.Close();

                return "Aluno cadastrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Aluno Buscar(string ra)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "SELECT * FROM Aluno WHERE ra = ?";

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", ra);

                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Aluno aluno = new Aluno();

                    aluno.setRA(dr["ra"].ToString());
                    aluno.setNome(dr["nome"].ToString());
                    aluno.setSexo(dr["sexo"].ToString());
                    aluno.setDataNasc(dr["data_nascimento"].ToString());
                    aluno.setTelefone(dr["telefone"].ToString());

                    conn.Close();
                    return aluno;
                }

                conn.Close();
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string Deletar(string ra)
        {
            try
            {
                OleDbConnection conn = ConexaoDAL.Conectar();

                string sql = "DELETE FROM Aluno WHERE ra = ?";

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", ra.Trim());

                int linhas = cmd.ExecuteNonQuery();

                conn.Close();

                if (linhas > 0)
                    return "Aluno excluído com sucesso!";
                else
                    return "Aluno não encontrado.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
