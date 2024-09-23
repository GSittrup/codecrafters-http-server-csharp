
namespace codecrafters_http_server.src.HandleRequests.ReadRequest;

public static class ReadHttpRequestLine
{
    private const string HTTPMETHOD = "HttpMethod";
    private const string REQUESTTARGET = "RequestTarget"; //Often a URL
    private const string HTTPVERSION = "HttpVersion";
    public static Dictionary<string, string> ReadRequestLine(string requestLine)
    {
        string[] requestSplit = requestLine.Split(" ");

        return new Dictionary<string, string>()
        {
            {HTTPMETHOD, requestSplit[0]},
            {REQUESTTARGET, requestSplit[1]},
            {HTTPVERSION, requestSplit[2]}
        };
    }
}