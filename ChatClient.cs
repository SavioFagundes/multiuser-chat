// ChatClient.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ChatClient
{
    private TcpClient client;
    private NetworkStream stream;
    private string username;

    public ChatClient(string ip, int port)
    {
        client = new TcpClient(ip, port);
        stream = client.GetStream();

        Console.Write("Digite seu nome: ");
        username = Console.ReadLine();

        Thread receiveThread = new(() => ReceiveMessages());
        receiveThread.Start();

        SendLoop();
    }

    private void SendLoop()
    {
        while (true)
        {
            string msg = Console.ReadLine();
            string formatted = $"{username}: {msg}";
            byte[] data = Encoding.UTF8.GetBytes(formatted);
            stream.Write(data, 0, data.Length);
        }
    }

    private void ReceiveMessages()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        while (true)
        {
            try
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"\n{msg}\n>> ");
            }
            catch
            {
                Console.WriteLine("Desconectado do servidor.");
                break;
            }
        }
    }
}
