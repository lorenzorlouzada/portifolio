using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulo
{
    class TrianguloBLL
    {
        public static void validaDados(Triangulo umtriangulo)
        {
            Erro.setErro(false);
            if (umtriangulo.getB().Length == 0)
            {
                Erro.setErro("O campo BASE é de preenchimento obrigatório...");
                return;
            }
            else
            {
                try
                {
                    float.Parse(umtriangulo.getB());
                }
                catch
                {
                    Erro.setErro("O campo BASE deve ser numérico...");
                    return;
                }
                if (float.Parse(umtriangulo.getB()) <= 0)
                {
                    Erro.setErro("O campo BASE deve ser maior que zero.");
                    return;
                }
            }

            if (umtriangulo.getH().Length == 0)
            {
                Erro.setErro("O campo ALTURA é de preenchimento obrigatório...");
                return;
            }
            else
            {
                try
                {
                    float.Parse(umtriangulo.getH());
                }
                catch
                {
                    Erro.setErro("O campo ALTURA deve ser numérico...");
                    return;
                }
                if (float.Parse(umtriangulo.getH()) <= 0)
                {
                    Erro.setErro("O campo ALTURA deve ser maior que zero.");
                    return;
                }

            }
        }
    }
}
