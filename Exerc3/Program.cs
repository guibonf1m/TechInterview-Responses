using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

class Program {
    class Faturamento {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main(string[] args) {
        string filePath = @"dados.json";

        try {
            var jsonData = File.ReadAllText(filePath);

            List<Faturamento> faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(jsonData);

            if (faturamentos == null || !faturamentos.Any()) {
                Console.WriteLine("Não foram encontrados dados válidos no arquivo JSON.");
                return;
            }

            var faturamentoValido = faturamentos.Where(f => f.Valor > 0).ToList();

            if (!faturamentoValido.Any()) {
                Console.WriteLine("Não há faturamento válido para calcular.");
                return;
            }

            double menorFaturamento = faturamentoValido.Min(f => f.Valor);
            double maiorFaturamento = faturamentoValido.Max(f => f.Valor);

            double mediaMensal = faturamentoValido.Average(f => f.Valor);

            int diasAcimaDaMedia = faturamentoValido.Count(f => f.Valor > mediaMensal);

            Console.WriteLine($"Menor faturamento: {menorFaturamento}");
            Console.WriteLine($"Maior faturamento: {maiorFaturamento}");
            Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaDaMedia}");
        }
        catch (FileNotFoundException) {
            Console.WriteLine($"Arquivo não encontrado: {filePath}");
        }
        catch (JsonException) {
            Console.WriteLine("Erro ao deserializar o arquivo JSON. Verifique o formato.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
