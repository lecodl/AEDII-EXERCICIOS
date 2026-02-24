using System;
using System.Collections.Generic;

class Produto
{
    int id;
    string nome;
    double preco;
    int estoque;

    internal Produto(int i, string n, double p, int e)
    {
        id = i;
        nome = n;
        preco = p;
        estoque = e;
    }

    internal int GetId() { return id; }
    internal string GetNome() { return nome; }
    internal double GetPreco() { return preco; }
    internal int GetEstoque() { return estoque; }

    internal void BaixarEstoque(int qtd)
    {
        estoque -= qtd;
    }

    internal void Mostrar()
    {
        Console.WriteLine("Id: " + id +
                          " | Nome: " + nome +
                          " | Preco: " + preco +
                          " | Estoque: " + estoque);
    }
}

class ItemPedido
{
    Produto produto;
    int quantidade;

    internal ItemPedido(Produto p, int q)
    {
        produto = p;
        quantidade = q;
    }

    internal double SubTotal()
    {
        return produto.GetPreco() * quantidade;
    }

    internal void AtualizarEstoque()
    {
        produto.BaixarEstoque(quantidade);
    }
}

class Pedido
{
    List<ItemPedido> itens = new List<ItemPedido>();

    internal void AdicionarItem(ItemPedido item)
    {
        itens.Add(item);
        item.AtualizarEstoque();
    }

    internal double Total()
    {
        double total = 0;
        foreach (ItemPedido i in itens)
            total += i.SubTotal();
        return total;
    }
}

class Pagamento
{
    internal virtual void Pagar(double valor)
    {
        Console.WriteLine("Pagamento realizado: " + valor);
    }
}

class Dinheiro : Pagamento
{
    internal override void Pagar(double valor)
    {
        Console.WriteLine("Pago em dinheiro: " + valor);
    }
}

class Cheque : Pagamento
{
    internal override void Pagar(double valor)
    {
        Console.WriteLine("Pago em cheque: " + valor);
    }
}

class Cartao : Pagamento
{
    internal override void Pagar(double valor)
    {
        Console.WriteLine("Pago em cartao: " + valor);
    }
}

class Program
{
    static void Main()
    {
        List<Produto> produtos = new List<Produto>();

        produtos.Add(new Produto(1, "Arroz", 20, 50));
        produtos.Add(new Produto(2, "Feijao", 10, 40));
        produtos.Add(new Produto(3, "Macarrao", 8, 30));

        Pedido pedido = new Pedido();

        while (true)
        {
            Console.WriteLine("\n1-Adicionar Item");
            Console.WriteLine("2-Finalizar Pedido");

            int op;
            int.TryParse(Console.ReadLine(), out op);

            if (op == 1)
            {
                Console.WriteLine("\nProdutos disponiveis:");
                foreach (Produto p in produtos)
                    p.Mostrar();

                Console.Write("Id produto: ");
                int id;
                int.TryParse(Console.ReadLine(), out id);

                Console.Write("Quantidade: ");
                int qtd;
                int.TryParse(Console.ReadLine(), out qtd);

                Produto prod = produtos.Find(x => x.GetId() == id);

                if (prod != null && prod.GetEstoque() >= qtd)
                {
                    pedido.AdicionarItem(new ItemPedido(prod, qtd));
                    Console.WriteLine("Item adicionado.");
                }
                else
                {
                    Console.WriteLine("Erro.");
                }
            }
            else if (op == 2)
            {
                double total = pedido.Total();
                Console.WriteLine("Total: " + total);

                Console.WriteLine("1-Dinheiro 2-Cheque 3-Cartao");
                int tipo;
                int.TryParse(Console.ReadLine(), out tipo);

                Pagamento pag = null;

                if (tipo == 1)
                    pag = new Dinheiro();
                else if (tipo == 2)
                    pag = new Cheque();
                else if (tipo == 3)
                    pag = new Cartao();

                if (pag != null)
                    pag.Pagar(total);

                break;
            }
        }
    }
}
