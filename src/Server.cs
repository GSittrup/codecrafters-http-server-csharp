using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

TcpListener server = new(IPAddress.Any, 4221);

try
{
    server.Start();
    var socket = server.AcceptSocket(); // wait for client

    var msg = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n\r\n");

    await socket.SendAsync(msg);
}
finally
{
    server.Stop();
}