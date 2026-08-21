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
        Console.WriteLine("Digite o nome do funcionário: ");
        string n = Console.ReadLine();

        Console.WriteLine("Digite o salário do funcionário: ");
        float s = float.Parse(Console.ReadLine());

        Funcionario f = new Funcionario(n, s);

        Console.WriteLine("O nome é: " + f.nome);
        Console.WriteLine("O salário é: R$" + f.salario);
        Console.ReadKey();
    }
}

//Exercício 3

using System;
class Program
{
    class NotaFiscal
    {
        public int numero, quant;
        public float preco;
        public string desc;

        public NotaFiscal(int numero, string desc, int quant, float preco)
        {
            this.numero = numero;
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

        Console.WriteLine("Digite o número do produto: ");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine("Descreva o produto: ");
        string desc = Console.ReadLine();

        Console.WriteLine("Digite quantas unidades foram vendidas: ");
        int quant = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o preço: ");
        int preco = int.Parse(Console.ReadLine());

        NotaFiscal nota = new NotaFiscal(numero, desc, quant, preco);

        double total = nota.getInvoiceAmount();

        Console.WriteLine("Número: " + nota.numero);
        Console.WriteLine("Descrição: " + nota.desc);
        Console.WriteLine("Quantidade: " + nota.quant);
        Console.WriteLine("Preço: R$" + nota.preco);
        Console.WriteLine("O total é: R$" + total);
        Console.ReadKey();
    }
}

//Exercício 4
using System;
class Program
{
    class Pessoa
    {
        public int idade;
        public float peso, altura;
        public string nome;

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


        static void Main(string[] args)
        {
            Console.WriteLine("---------- Dados do Paciente ----------");

            int idade;
            string nome;

            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Idade: ");
            idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Peso: ");
            float peso = float.Parse(Console.ReadLine());

            Console.WriteLine("Altura: ");
            float altura = float.Parse(Console.ReadLine());

            Pessoa p = new Pessoa(nome, idade, altura, peso);

            Console.Clear();

            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
            Console.WriteLine("Peso: " + peso);
            Console.WriteLine("Altura: " + altura);

            Console.WriteLine("---------- Alterando dados do Paciente ----------");

            Console.WriteLine("Digite o novo nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Novo nome alterado! " + p.alteraNome(nome));

            Console.WriteLine("Digite a nova idade: ");
            idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Nova idade alterada! " + p.alteraIdade(idade));

            Console.ReadKey();
        }
    }
}

//Exercício 5
using System;
class Program
{
    class calculaPessoa
    {
        public int idade;
        public float peso, altura, resultado;
        public string nome;

        public calculaPessoa(string nome, int idade, float peso, float altura)
        {
            this.nome = nome;
            this.idade = idade;
            this.peso = peso;
            this.altura = altura;

            resultado = peso / ((altura / 100) * (altura / 100));

        }

        public string defineClasse()
        {
            string classe;

            if (this.resultado <= 20)
            {
                classe = "Abaixo do peso";
            }
            else if (this.resultado > 20 || this.resultado <= 25)
            {
                classe = "Peso normal";
            }
            else if (this.resultado > 25 || this.resultado <= 30)
            {
                classe = "Sobrepeso";
            }
            else if (this.resultado > 30 || this.resultado <= 35)
            {
                classe = "Obesidade grau 1";
            }
            else if (this.resultado > 35 || this.resultado <= 40)
            {
                classe = "Obesidade Grau 2";
            }
            else
            {
                classe = "Obesidade Grau 3";
            }

            return classe;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("---------- Dados do Paciente ----------");

            int idade;
            string nome;

            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Idade: ");
            idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Peso: ");
            float peso = float.Parse(Console.ReadLine());

            Console.WriteLine("Altura: ");
            float altura = float.Parse(Console.ReadLine());

            calculaPessoa p = new calculaPessoa(nome, idade, peso, altura);

            Console.Clear();

            float resultado;

            string classe;

            classe = p.defineClasse();

            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
            Console.WriteLine("Peso: " + peso);
            Console.WriteLine("Altura: " + altura);
            Console.WriteLine("Resultado: " + p.resultado);
            Console.WriteLine("Classe: " + classe);

            Console.ReadKey();
        }
    }
}



//Exercício 6
class program
{
    class investimento
    {
        double capital;
        double taxaJ;

        public investimento(double capital, double taxaJ)
        {
            this.capital = capital;
            this.taxaJ = taxaJ;
        }
        public void CalcularRendimento()
        {
            Console.WriteLine("valor inicial do investimento: R$ " + capital.ToString("F2"));
            double valorAtual = capital;

            for (int mes = 1; mes <= 12; mes++)
            {
                valorAtual += valorAtual * taxaJ;
                Console.WriteLine($"Mes {mes}: R$ {valorAtual:F2}");
            }
        }
    }
    static void Main(String[] args)
    {
        Console.Write("Digite o valor do capital investido: ");
        double capital = double.Parse(Console.ReadLine());

        Console.WriteLine("Digite a taxa de juros: ");
        double taxaJ = double.Parse(Console.ReadLine());
        investimento investimento = new investimento(capital, taxaJ);

        investimento.CalcularRendimento();
    }
}
