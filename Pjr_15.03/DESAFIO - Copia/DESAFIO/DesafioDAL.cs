using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO
{
    
        public class DesafioDAL
        {
            public static string gerarClasse(string nomeClasse, List<string> propriedades)
            {
                StringBuilder codigo = new StringBuilder();

                codigo.AppendLine("public class " + nomeClasse);
                codigo.AppendLine("{");

                foreach (string p in propriedades)
                {
                    codigo.AppendLine("   private string " + p + ";");
                }

                codigo.AppendLine();

                foreach (string p in propriedades)
                {


                    codigo.AppendLine("   public string" + p + ";");

                    codigo.AppendLine("   public string get" + p + "()");
                    codigo.AppendLine("   {");
                    codigo.AppendLine("       return " + p + ";");
                    codigo.AppendLine("   }");

                    codigo.AppendLine("   public void set" + p + "(string _" + p + ")");
                    codigo.AppendLine("   {");
                    codigo.AppendLine("       " + p + " = _" + p + ";");
                    codigo.AppendLine("   }");
                }

                codigo.AppendLine("}");

                return codigo.ToString();
            }
        }
    
}

