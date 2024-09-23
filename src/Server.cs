using System.Net;
using System.Net.Sockets;
using System.Text;
using codecrafters_http_server.src.HandleRequests.ReadRequest;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

TcpListener server = new(IPAddress.Any, 4221);

var succesResponse = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n\r\n");
var notFoundResponse = Encoding.UTF8.GetBytes("HTTP/1.1 404 Not Found\r\n\r\n");

try
{
    server.Start();

    // Buffer for reading data
    var bytes = new byte[256];
    var data = string.Empty;

    var requestLine = string.Empty;
    var requestHeader = string.Empty;

    while (true)
    {
        using TcpClient client = server.AcceptTcpClient();
        
        var stream = client.GetStream();

        int i; 
        while((i = stream.Read(bytes, 0, bytes.Length))!=0)
        {
            data = Encoding.ASCII.GetString(bytes, 0, i);

            var request = ReadHttpRequest.SplitRequest(data);

            requestLine = request["RequestLine"];
            requestHeader = request["RequestHeader"];

            var splittedRequestLine = ReadHttpRequestLine.ReadRequestLine(requestLine);

            if(splittedRequestLine["RequestTarget"].Equals("/")) 
                await stream.WriteAsync(succesResponse);

            await stream.WriteAsync(notFoundResponse);
        }
    }
}
finally
{
    server.Stop();
}