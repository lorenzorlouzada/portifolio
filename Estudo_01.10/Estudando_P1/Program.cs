//Exercício 1
using System;
class Program
{
    class Funcionario
    {
        public string nome;
        public float salario;
    }

    static void Main(string[] args)
    {
        Funcionario f = new Funcionario();
    }
}

//Exercício 2
using System;
class Program
{
    class Funcionario
    {
        public string nome;
        public float salario;

        public Funcionario(string nome, float salario)
        {
            this.nome = nome;
            this.salario = salario;
        }
    }

    static void Main(string[] args)
    {
        string n;
        float s;

        Console.Write("Digite o nome do funcionário: ");
        n = Console.ReadLine();

        Console.Write("Digite o salário do funcionário: ");
        s = float.Parse(Console.ReadLine());

        Funcionario f = new Funcionario(n, s);

        Console.WriteLine("O nome é: " + f.nome);
        Console.WriteLine("O salário é: R$" + f.salario);
        Console.ReadKey();
    }
}

//Exercício 3
using System;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
class Program
{
    class NotaFiscal
    {
        public int numProd;
        public string desc;
        public int quant;
        public float preco;

        public NotaFiscal(int numProd, string desc, int quant, float preco)
        {
            this.numProd = numProd;
            this.desc = desc;
            this.quant = quant;
            this.preco = preco;
        }

        public double getInvoiceAmount()
        {
            return quant * preco;
        }
    }

    static void Main(string[] args)
    {
        int numProd, quant;
        string desc;
        float preco;
        double total;

        Console.Write("Digite o número do produto: ");
        numProd = int.Parse(Console.ReadLine());

        Console.Write("Descrição do produto: ");
        desc = Console.ReadLine();

        Console.Write("Informe a quantidade vendida: ");
        quant = int.Parse(Console.ReadLine());

        Console.Write("Informe o preço deste produto: ");
        preco = float.Parse(Console.ReadLine());

        NotaFiscal nota = new NotaFiscal(numProd, desc, quant, preco);

        total = nota.getInvoiceAmount();

        Console.WriteLine("Número: " + nota.numProd);
        Console.WriteLine("Descrição: " + nota.desc);
        Console.WriteLine("Quantidade: " + nota.quant);
        Console.WriteLine("Preço: " + nota.preco);
        Console.WriteLine("O valor final é: R$" + total);
        Console.ReadKey();

    }
}


//Exercício 4
using System;

class Program
{
    class Pessoa
    {
        public string nome;
        public int idade;
        public float peso;
        public float altura;

        public Pessoa(string nome, int idade, float peso, float altura)
        {
            this.nome = nome;
            this.idade = idade;
            this.peso = peso;
            this.altura = altura;
        }

        public string alteraNome(string novoNome)
        {
            nome = novoNome;
            return nome;
        }

        public int alteraIdade(int novaIdade)
        {
            idade = novaIdade;
            return idade;
        }

        public float alteraPeso(float novoPeso)
        {
            peso = novoPeso;
            return peso;
        }

        public float alteraAltura(float novaAltura)
        {
            altura = novaAltura;
            return altura;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("---------- Dados do Paciente ----------");

        int idade;
        string nome;
        float peso, altura;

        Console.Write("Nome: ");
        nome = Console.ReadLine();

        Console.Write("Idade: ");
        idade = int.Parse(Console.ReadLine());

        Console.Write("Peso: ");
        peso = float.Parse(Console.ReadLine());

        Console.Write("Altura: ");
        altura = float.Parse(Console.ReadLine());

        Pessoa p = new Pessoa(nome, idade, peso, altura);

        Console.Clear();

        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Idade: " + idade);
        Console.WriteLine("Peso: " + peso);
        Console.WriteLine("Altura: " + altura);
        Console.ReadKey();

        Console.WriteLine("---------- Dados do Paciente ----------");

        Console.WriteLine("Digite o novo nome: ");
        nome = Console.ReadLine();
        Console.WriteLine("Novo nome alterado! O novo nome é: " + p.alteraNome(nome));

        Console.WriteLine("Digite a nova idade: ");
        idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Nova idade alterada! A nova idade é: " + p.alteraIdade(idade));

        Console.ReadKey();

    }
}
