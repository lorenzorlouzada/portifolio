using System;
class Veiculo
{
    public virtual double CalculaPreco(double preco)
    {
        return preco * 1.10;
    }
}
class CalculaLivro : Produtos
{
    public override double CalculaPreco(double preco)
    {
        return preco * 1.20; ;
    }
}
class CalculaEletronicos : CalculaLivro
{
    public override double CalculaPreco(double preco)
    {
        return preco * 1.40; ;
    }
}
class CalculaRoupa : CalculaLivro
{
    public override double CalculaPreco(double preco)
    {
        return preco * 1.25; ;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Produtos CalculaLivro = new CalculaLivro();
        Produtos CalculaEletronicos = new CalculaEletronicos();
        Produtos CalculaRoupa = new CalculaRoupa();
        double resultadoLivro = CalculaLivro.CalculaPreco(30);
        double resultadoEletronico = CalculaEletronicos.CalculaPreco
        (1350);
        double resultadoRoupa = CalculaRoupa.CalculaPreco(200);
        Console.WriteLine("Frete livro: " + resultadoLivro);
        Console.WriteLine("Frete livro: " + resultadoEletronico);
        Console.WriteLine("Frete livro: " + resultadoRoupa);
        Console.ReadKey();
    }
}