using System;
using System.Collections.Generic;

class Pessoa
{
    string nome;
    int idade;
    Pessoa pai;
    Pessoa mae;

    internal Pessoa(string nome, int idade)
    {
        this.nome = nome;
        this.idade = idade;
    }

    internal string Nome() { return nome; }
    internal int Idade() { return idade; }

    internal void SetPai(Pessoa p)
    {
        pai = p;
    }

    internal void SetMae(Pessoa m)
    {
        mae = m;
    }

    internal void MostrarArvore(int nivel)
    {
        string espaco = new string(' ', nivel * 4);
        Console.WriteLine(espaco + "- " + nome + " (" + idade + " anos)");

        if (pai != null)
        {
            Console.WriteLine(espaco + "  Pai:");
            pai.MostrarArvore(nivel + 1);
        }

        if (mae != null)
        {
            Console.WriteLine(espaco + "  Mae:");
            mae.MostrarArvore(nivel + 1);
        }
    }
}

class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - Cadastrar pessoa");
            Console.WriteLine("2 - Listar pessoas");
            Console.WriteLine("3 - Mostrar arvore");

            string op = Console.ReadLine();

            if (op == "1")
                Cadastrar();
            else if (op == "2")
                Listar();
            else if (op == "3")
                Mostrar();
        }
    }

    static void Cadastrar()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Idade: ");
        int idade;
        int.TryParse(Console.ReadLine(), out idade);

        Pessoa p = new Pessoa(nome, idade);

        if (pessoas.Count > 0)
        {
            Console.Write("Tem pai cadastrado? (s/n): ");
            string resp = Console.ReadLine();

            if (resp == "s")
            {
                Listar();
                Console.Write("Indice do pai: ");
                int i;
                int.TryParse(Console.ReadLine(), out i);

                if (i >= 0 && i < pessoas.Count)
                    p.SetPai(pessoas[i]);
            }

            Console.Write("Tem mae cadastrada? (s/n): ");
            resp = Console.ReadLine();

            if (resp == "s")
            {
                Listar();
                Console.Write("Indice da mae: ");
                int i;
                int.TryParse(Console.ReadLine(), out i);

                if (i >= 0 && i < pessoas.Count)
                    p.SetMae(pessoas[i]);
            }
        }

        pessoas.Add(p);
        Console.WriteLine("Pessoa cadastrada.");
    }

    static void Listar()
    {
        if (pessoas.Count == 0)
        {
            Console.WriteLine("Nenhuma pessoa cadastrada.");
            return;
        }

        for (int i = 0; i < pessoas.Count; i++)
        {
            Console.WriteLine(i + " - " + pessoas[i].Nome() +
                              " (" + pessoas[i].Idade() + " anos)");
        }
    }

    static void Mostrar()
    {
        if (pessoas.Count == 0)
        {
            Console.WriteLine("Nenhuma pessoa cadastrada.");
            return;
        }

        Listar();
        Console.Write("Indice da pessoa: ");
        int i;
        int.TryParse(Console.ReadLine(), out i);

        if (i >= 0 && i < pessoas.Count)
        {
            Console.WriteLine("\nArvore genealogica:");
            pessoas[i].MostrarArvore(0);
        }
    }
}
