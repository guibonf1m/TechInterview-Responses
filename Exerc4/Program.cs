using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double> {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double faturamentoTotal = 0;
        foreach (var faturamento in faturamentoPorEstado.Values) {
            faturamentoTotal += faturamento;
        }

        Console.WriteLine("Percentual de representação de cada estado:");
        foreach (var estado in faturamentoPorEstado) {
            double percentual = (estado.Value / faturamentoTotal) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
    }
}