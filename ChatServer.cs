// ChatServer.cs
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

public class ChatServer
{
    private TcpListener server;
    private List<TcpClient> clients = new();
    private readonly object lockObj = new();

    public ChatServer(int port)
    {
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        Console.WriteLine($"Servidor iniciado na porta {port}");
        AcceptClients();
    }

    private void AcceptClients()
    {
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            lock (lockObj) clients.Add(client);
            Console.WriteLine("Novo cliente conectado.");
            Thread thread = new(() => HandleClient(client));
            thread.Start();
        }
    }

    private void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Recebido: {msg.Trim()}");
                Broadcast(msg, client);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Cliente desconectado.");
        }
        finally
        {
            lock (lockObj) clients.Remove(client);
            client.Close();
        }
    }

    private void Broadcast(string msg, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(msg);
        lock (lockObj)
        {
            foreach (var client in clients)
            {
                if (client != sender)
                {
                    try
                    {
                        client.GetStream().Write(data, 0, data.Length);
                    }
                    catch { }
                }
            }
        }
    }
}
