//Exercício 1
using System;

class Program
{
    static void Main(string[] args)
    {
        int mes = month();
        string escrito = mesextenso(mes);
        Console.WriteLine("O nome do mês {0} é 1", mbox, escrito);
    }
    static int month()
    {
        int mes;
        Console.WriteLine("Digite um número de 1 a 12");
        mes =int.Parse(Console.ReadLine());

        while (mes < 1 || mes > 12)
        { 
            Console.WriteLine("Digite um número de 1 a 12!")
            Console.Write();
            Console.WriteLine("Digite de novo, um valor entre 1 e 12: ");
            mes = int.Parse(Console.ReadLine());
        }
        return mes;
    }
    static string mesextenso(int mes)
    { 
        string[] extenso = {"January", "February", "March", "April", "May", "June", "July", "September", "November", "Ouctober", "November", "December"}
        return extenso[mes - 1];
    }
}

//Exercício 2
using System;
class Program
{
    static void Main(string[] args)
    {

        int n = 0;

        while (n <= 0 || n > 100)
        {
            Console.WriteLine("Digite um número: ");
            n = int.Parse(Console.ReadLine());

        }

        int[,] array = new int[n, n];
        int comeco = 0, final = n - 1, valor = 1;

        do
        {
            for (int j = comeco; j <= final; j++)
            {
                array[comeco, j] = valor;
            }

            for (int j = comeco; j <= final; j++)
            {
                array[final, j] = valor;
            }

            for (int i = comeco; i <= final; i++)
            {
                array[i, comeco] = valor;
            }

            for (int i = comeco; i <= final; i++)
            {
                array[i, final] = valor;
            }
            comeco++;
            final--;
            valor++;
        } while (comeco <= final);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j == 0)
                {
                    Console.Write($"{array[i, j],3}");
                }
                else
                {
                    Console.Write($"{array[i, j],3}");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.ReadKey();
    }
}