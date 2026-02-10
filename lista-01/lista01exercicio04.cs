/*
Para cada produto informado (nome, preço e quantidade), escreva o nome do produto
comprado e o valor total a ser pago, considerando que são oferecidos descontos pelo
número de unidades compradas, segundo a tabela abaixo:

a. Até 10 unidades: valor total
b. de 11 a 20 unidades: 10% de desconto
c. de 21 a 50 unidades: 20% de desconto
d. acima de 50 unidades: 25% de desconto
*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("Quantidade comprada: ");
        int quantidade = int.Parse(Console.ReadLine());

        double total = preco * quantidade;

        if (quantidade >= 11 && quantidade <= 20)
            total *= 0.9; // 10% de desconto
        else if (quantidade >= 21 && quantidade <= 50)
            total *= 0.8; // 20% de desconto
        else if (quantidade > 50)
            total *= 0.75; // 25% de desconto

        Console.WriteLine($"Produto: {nome}");
        Console.WriteLine($"Valor total a pagar: {total:F2}");
    }
}
