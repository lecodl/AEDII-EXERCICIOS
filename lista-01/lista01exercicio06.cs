// Determine o número de dígitos de um número informado

using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número: ");
        int numero = int.Parse(Console.ReadLine());

        int digitos = numero.ToString().Length;

        Console.WriteLine($"O número de dígitos é: {digitos}");
    }
}
