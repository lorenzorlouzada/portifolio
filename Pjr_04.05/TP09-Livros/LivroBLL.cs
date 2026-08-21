using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace TP09_Livros
{
    using System.Data.OleDb;

    class LivroBLL
    {
        public static void conecta()
        {
            LivroDAL.conecta();
        }

        public static void desconecta()
        {
            LivroDAL.desconecta();
        }

        public static OleDbDataReader listaLivros()
        {
            return LivroDAL.listaLivros();
        }
    }
}
