namespace codecrafters_http_server.src.HandleRequests.Response;

public class HttpResponses
{
    public static string RequestTargetSwitch(string requestTarget){
        System.Console.WriteLine(requestTarget);

        if(requestTarget.Equals("/")) return "HTTP/1.1 200 OK\r\n\r\n";
        if(requestTarget.Contains("/echo/")) return EchoRequest(requestTarget);

        else return "HTTP/1.1 404 Not Found\r\n\r\n";
    }

    private static string EchoRequest(string requestTarget){

        var split = "echo/";

        string content = requestTarget.Substring(requestTarget.IndexOf(split) + split.Length);

        var length = content.Length; 

        return $"HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\nContent-Length: {length}\r\n\r\n{content}";
    }
}