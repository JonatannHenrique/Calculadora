using System;
using System.Globalization;

namespace CalculaTest
{
    internal enum Operacao
    {
        Soma,
        Subtracao,
        Multiplicacao,
        Divisao,
        Potencia,
        Modulo
    }

    internal static class Calculadora
    {
        public static bool TryParseOperacao(string token, out Operacao operacao)
        {
            operacao = Operacao.Soma;
            if (string.IsNullOrWhiteSpace(token)) return false;

            token = token.Trim().ToLowerInvariant();
            switch (token)
            {
                case "+":
                case "soma":
                case "add":
                    operacao = Operacao.Soma;
                    return true;
                case "-":
                case "sub":
                case "subtracao":
                case "menos":
                    operacao = Operacao.Subtracao;
                    return true;
                case "*":
                case "x":
                case "mul":
                case "multiplicacao":
                case "multiplicaçao":
                    operacao = Operacao.Multiplicacao;
                    return true;
                case "/":
                case "div":
                case "divisao":
                case "divisão":
                    operacao = Operacao.Divisao;
                    return true;
                case "^":
                case "pow":
                case "pot":
                case "potencia":
                case "potência":
                    operacao = Operacao.Potencia;
                    return true;
                case "%":
                case "mod":
                case "modulo":
                case "módulo":
                    operacao = Operacao.Modulo;
                    return true;
                default:
                    return false;
            }
        }

        public static bool TryCalcular(double a, double b, Operacao operacao, out double resultado, out string erro)
        {
            resultado = double.NaN;
            erro = null;

            try
            {
                switch (operacao)
                {
                    case Operacao.Soma:
                        resultado = a + b;
                        break;
                    case Operacao.Subtracao:
                        resultado = a - b;
                        break;
                    case Operacao.Multiplicacao:
                        resultado = a * b;
                        break;
                    case Operacao.Divisao:
                        if (b == 0)
                        {
                            erro = "Erro: divisão por zero.";
                            return false;
                        }
                        resultado = a / b;
                        break;
                    case Operacao.Potencia:
                        resultado = Math.Pow(a, b);
                        break;
                    case Operacao.Modulo:
                        if (b == 0)
                        {
                            erro = "Erro: módulo por zero.";
                            return false;
                        }
                        resultado = a % b;
                        break;
                    default:
                        erro = "Operação desconhecida.";
                        return false;
                }

                if (double.IsInfinity(resultado) || double.IsNaN(resultado))
                {
                    erro = "Resultado inválido (overflow ou operação indefinida).";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                erro = "Erro inesperado: " + ex.Message;
                return false;
            }
        }

        public static bool TryParseDoubleFlexible(string input, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input)) return false;

            input = input.Trim();

            
            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
                return true;

            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value))
                return true;

      
            var alt = input.Replace(',', '.');
            if (double.TryParse(alt, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value))
                return true;

            alt = input.Replace('.', ',');
            if (double.TryParse(alt, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
                return true;

            return false;
        }
    }
}
