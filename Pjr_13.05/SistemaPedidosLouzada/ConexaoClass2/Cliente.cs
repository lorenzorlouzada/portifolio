using System;

namespace ConexaoClass2
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Perfil { get; set; }

        public string GerarCodigoPedido()
        {
            string telefone = Telefone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            string ddd = telefone.Substring(0, 2);
            string ultimos = telefone.Substring(telefone.Length - 4, 4);
            return ddd + "-" + ultimos;
        }
    }
}