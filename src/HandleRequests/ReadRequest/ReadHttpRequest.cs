namespace codecrafters_http_server.src.HandleRequests.ReadRequest;

public static class ReadHttpRequest
{
    private const string REQUESTLINE = "RequestLine";
    private const string REQUESTHEADER = "RequestHeader";

    public static Dictionary<string, string> SplitRequest(string request)
    {
        string[] requestSplit = request.Split('\n');

        return new Dictionary<string, string>()
        {
            {REQUESTLINE, requestSplit[0]},
            {REQUESTHEADER, requestSplit[1]}
        };
    }
}