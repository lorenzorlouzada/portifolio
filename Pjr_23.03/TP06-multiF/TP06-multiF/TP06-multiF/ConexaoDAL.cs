using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace TP06_multiF
{
    public class ConexaoDAL
    {
        private static string strConexao =
        "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = BDAulas.mdb";

        public static OleDbConnection Conectar()
        {
            OleDbConnection conn = new OleDbConnection(strConexao);
            conn.Open();
            return conn;
        }

    }
}
