using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTest
{
    internal class Calculadora
    {
        public static double calcular(double a, double b, string operacao)
        {
            if (operacao == "+") return a + b;
            if (operacao == "-") return a + b;
            if (operacao == "*") return a + b;
            if (operacao == "/")

                return a / b;

            return double.NaN;
        }
    }
}
