using System;

namespace CalculaTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora simples — digite 'sair' para encerrar.");
            while (true)
            {
                Console.WriteLine();
                Console.Write("Digite o primeiro número: ");
                string raw1 = Console.ReadLine();
                if (IsExit(raw1)) break;

                Console.Write("Escolha operação (+, -, *, /, ^, %, ou palavras: soma, sub, mul, div, pot, mod): ");
                string opRaw = Console.ReadLine();
                if (IsExit(opRaw)) break;

                Console.Write("Digite o segundo número: ");
                string raw2 = Console.ReadLine();
                if (IsExit(raw2)) break;

                if (!Calculadora.TryParseDoubleFlexible(raw1, out double num1))
                {
                    Console.WriteLine("Entrada inválida para o primeiro número.");
                    continue;
                }

                if (!Calculadora.TryParseDoubleFlexible(raw2, out double num2))
                {
                    Console.WriteLine("Entrada inválida para o segundo número.");
                    continue;
                }

                if (!Calculadora.TryParseOperacao(opRaw, out Operacao operacao))
                {
                    Console.WriteLine("Operação inválida. Exemplos válidos: + - * / ^ %");
                    continue;
                }

                if (Calculadora.TryCalcular(num1, num2, operacao, out double resultado, out string erro))
                {
                    Console.WriteLine("Resultado: " + resultado);
                }
                else
                {
                    Console.WriteLine(erro);
                }
            }
        }

        private static bool IsExit(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            var t = input.Trim().ToLowerInvariant();
            return t == "sair" || t == "exit" || t == "q" || t == "quit" || t == "s" || t == "Sair" || t == "Exit" || t == "Q" || t == "S" || t == "Quit";
        }
    }
}
