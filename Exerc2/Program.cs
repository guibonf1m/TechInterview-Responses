using System;

namespace RespostasTecnicas {

    public class Program {

        public static void Main() {
            Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
            int numero = int.Parse(Console.ReadLine());

            if (EhFibonacci(numero)) {
                Console.WriteLine("O número " + numero + " pertence à sequência de Fibonacci.");
            }
            else {
                Console.WriteLine("O número " + numero + " não pertence à sequência de Fibonacci.");
            }
        }

        public static bool EhFibonacci(int numero) {
            int a = 0, b = 1, temp;

            while (a < numero) {
                temp = a;
                a = b;
                b = temp + b;
            }
            return a == numero;
        }
    }
}

