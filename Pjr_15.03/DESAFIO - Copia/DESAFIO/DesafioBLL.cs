using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO
{

    public class DesafioBLL
    {
        public static void validarClasse(string nomeClasse)
        {
            Erro.limpar();

            if (nomeClasse.Trim().Length == 0)
            {
                Erro.setErro("Nome da classe é obrigatório.");
                return;
            }
        }

        public static void validarPropriedade(string prop)
        {
            if (prop.Trim().Length == 0)
            {
                Erro.setErro("Propriedade inválida.");
                return;
            }
        }


    }
}


