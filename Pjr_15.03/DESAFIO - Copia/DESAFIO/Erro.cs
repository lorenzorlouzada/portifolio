using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO
{
    public class Erro
    {
        public static bool temErro = false;
        public static string mensagem = "";

        public static void setErro(string msg)
        {
            temErro = true;
            mensagem = msg;
        }

        public static void limpar()
        {
            temErro = false;
            mensagem = "";
        }
    }
}
