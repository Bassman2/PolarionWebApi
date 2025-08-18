namespace PolarionWebApi;

public sealed class Polarion : JsonService
{
    public Polarion(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Polarion(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    protected override string? AuthenticationTestUrl => null;

    protected override void InitializeClient(HttpClient client)
    {
        base.InitializeClient(client);
        client.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

        //client.DefaultRequestHeaders.MaxForwards = 5;
    }

    public async Task<IEnumerable<Project>?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<ResponseListModel>("rest/v1/projects", cancellationToken);
        return res?.Data.CastModel<Project>();
    }

    public async Task<Project?> GetProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));

        string req = CombineUrl("rest/v1/projects/", projectId,
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseItemModel>(req, cancellationToken);
        return res?.Data.CastModel<Project>();
    }

    public async Task<Project?> GetCollectionsAsync(string projectId, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));

        string req = CombineUrl("rest/v1/projects/", projectId, "/collections",
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseListModel>(req, cancellationToken);
        return res.CastModel<Project>();
    }

    public async Task<IEnumerable<Workitem>?> GetWorkitemsAsync(string projectId, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));

        string req = CombineUrl("rest/v1/projects/", projectId, "/workitems",
            ("fields[categories]", "@all"),
            ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseListModel>(req, cancellationToken);
        return res?.Data.CastModel<Workitem>();
    }

    public async Task<Workitem?> GetWorkitemAsync(string projectId, string workitemId, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));
        ArgumentNullException.ThrowIfNullOrEmpty(workitemId, nameof(workitemId));

        string req = CombineUrl("rest/v1/projects/", projectId, "/workitems", workitemId,
           ("fields[categories]", "@all"),
           ("fields[collections]", "@basic"));
        var res = await GetFromJsonAsync<ResponseItemModel>(req, cancellationToken);
        return res?.Data.CastModel<Workitem>();
    }
}
