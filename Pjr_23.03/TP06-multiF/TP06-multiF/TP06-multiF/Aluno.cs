using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP06_multiF
{
    public class Aluno
    {

        public String RA;
        public String nome;
        public String sexo;
        public String dataNasc;
        public   String telefone;

        public void setNome(String _nome) { nome = _nome; }
        public void setRA(String _RA) { RA = _RA; }
        public void setSexo(String _sexo) { sexo = _sexo; }
        public void setDataNasc(String _dataNasc) { dataNasc = _dataNasc; }

        public void setTelefone(String _telefone) { telefone = _telefone; }

        public String getRA() { return RA; }
        public String getNome() { return nome; }
        public String getDataNasc() { return dataNasc; }
        public String getSexo() { return sexo; }

        public String getTelefone() { return telefone; }

    }
}

