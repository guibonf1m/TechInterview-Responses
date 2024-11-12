using System;

class Program {
    static void Main() {
        string input = "Bonfim"; 

        string inverted = "";

        for (int i = input.Length - 1; i >= 0; i--) {
            inverted += input[i];
        }

        Console.WriteLine("String invertida: " + inverted);
    }
}