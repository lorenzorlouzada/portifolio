using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06_multiF
{
    public class AlunoBLL
    {
        public string ValidarAluno(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.nome) ||
                string.IsNullOrWhiteSpace(aluno.sexo) ||
                string.IsNullOrWhiteSpace(aluno.dataNasc) ||
                string.IsNullOrWhiteSpace(aluno.telefone))
            {
                return "Todos os campos são obrigatórios.";
            }

            if (aluno.sexo != "Masculino" && aluno.sexo != "Feminino")
            {
                return "O sexo deve ser Masculino ou Feminino.";
            }

            DateTime data;
            if (!DateTime.TryParse(aluno.dataNasc, out data))
            {
                return "Data de nascimento inválida.";
            }

            return "OK";
        }

        public string Salvar(Aluno aluno)
        {
            string resultado = ValidarAluno(aluno);

            if (resultado != "OK")
            {
                return resultado;
            }

            return AlunoDAL.Inserir(aluno);
        }
        public Aluno Buscar(string ra)
        {
            return AlunoDAL.Buscar(ra);
        }

        public string Deletar(string ra)
        {
            if (string.IsNullOrWhiteSpace(ra))
                return "Informe o RA.";

            return AlunoDAL.Deletar(ra);
        }
    }


}

