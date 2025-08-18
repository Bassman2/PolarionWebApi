namespace PolarionWebApi.Service;

internal sealed class PolarionService(Uri host, IAuthenticator? authenticator, string appName) : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    protected override string? AuthenticationTestUrl => null;

    protected override void InitializeClient(HttpClient client)
    {
        base.InitializeClient(client);
        client.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

        //client.DefaultRequestHeaders.MaxForwards = 5;
    }

    //protected override async Task ErrorCheckAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    if (!response.IsSuccessStatusCode)
    //    {
    //        await ErrorHandlingAsync(response, memberName, cancellationToken);
    //    }
    //}

    //protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    string res = response.Content.ReadAsStringAsync(cancellationToken).Result;
    //    if (res.StartsWith('{'))
    //    {
    //        JsonTypeInfo<ErrorModel> jsonTypeInfoOut = (JsonTypeInfo<ErrorModel>)context.GetTypeInfo(typeof(ErrorModel))!;
    //        var error = await response.Content.ReadFromJsonAsync<ErrorModel>(jsonTypeInfoOut, cancellationToken);
    //        res = error?.ToString() ?? "Unknown";
    //    }
    //    throw new WebServiceException(res, response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    //}

    public async Task<ResponseListModel?> GetProjectsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ResponseListModel>("rest/v1/projects", cancellationToken);
        return res;
    }

    public async Task<ResponseItemModel?> GetProjectAsync(string projectId, CancellationToken cancellationToken)
    {
        string req = CombineUrl("rest/v1/projects/", projectId, 
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseItemModel>(req, cancellationToken);
        return res;
    }

    public async Task<ResponseListModel?> GetCollectionsAsync(string projectId, CancellationToken cancellationToken)
    {
        string req = CombineUrl("rest/v1/projects/", projectId, "/collections",
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseListModel>(req, cancellationToken);
        return res;
    }

    public async Task<ResponseListModel?> GetPlansAsync(string projectId, CancellationToken cancellationToken)
    {
        string req = CombineUrl("rest/v1/projects/", projectId, "/plans",
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseListModel>(req, cancellationToken);
        return res;
    }

    public async Task<ResponseListModel?> GetWorkitemsAsync(string projectId, CancellationToken cancellationToken)
    {
        string req = CombineUrl("rest/v1/projects/", projectId, "/workitems",
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseListModel>(req, cancellationToken);
        return res;
    }

    public async Task<ResponseItemModel?> GetWorkitemAsync(string projectId, string workitemId, CancellationToken cancellationToken)
    {
        string req = CombineUrl("rest/v1/projects/", projectId, "/workitems", workitemId,
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseItemModel>(req, cancellationToken);
        return res;
    }
}
