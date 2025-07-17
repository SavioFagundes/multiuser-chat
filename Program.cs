// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite 's' para servidor ou 'c' para cliente: ");
        string escolha = Console.ReadLine();

        if (escolha.ToLower() == "s")
        {
            Console.Write("Porta: ");
            int porta = int.Parse(Console.ReadLine());
            new ChatServer(porta);
        }
        else
        {
            Console.Write("IP do servidor: ");
            string ip = Console.ReadLine();
            Console.Write("Porta: ");
            int porta = int.Parse(Console.ReadLine());
            new ChatClient(ip, porta);
        }
    }
}
