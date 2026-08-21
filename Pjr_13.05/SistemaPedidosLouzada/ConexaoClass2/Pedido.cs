using System;
using System.Collections.Generic;

namespace ConexaoClass2
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public List<ItemPedido> Itens { get; set; }
    }
}