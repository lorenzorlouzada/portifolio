namespace SistemaClass
{
    public class Produto
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal Preco { get; set; }
        public bool TemFoto { get; set; }
        public bool Ativo { get; set; }
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; } = "";
    }
}