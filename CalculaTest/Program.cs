using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("↓ CALCULADORA ↓");
                Console.Write("Digite o primeiro numero: ");
                string n1 = Console.ReadLine();
                Console.WriteLine("Escolha (+ <Mas , - <menos, / < divisão , * < multiplicaçao )");
                string op = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Digite o Segundo Numero: ");
                string n2 = Console.ReadLine();

                if (double.TryParse(n1, out double num1) && double.TryParse(n2, out double num2))
                {
                    double resultado = Calculadora.calcular(num1, num2, op);
                    Console.WriteLine("Resultado: " + resultado);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
