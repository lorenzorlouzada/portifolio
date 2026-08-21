namespace SistemaClass
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int? IdTamanho { get; set; }
        public string NomeProduto { get; set; }
        public string NomeTamanho { get; set; }
        public decimal Preco { get; set; }
    }
}