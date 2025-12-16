using System.Text.RegularExpressions;

namespace PolarionWebApi;

public sealed partial class Polarion : JsonService
{
    public Polarion(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Polarion(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Configures the provided <see cref="HttpClient"/> instance with specific default headers required for API requests.
    /// This includes setting the User-Agent, Accept, and API version headers.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to configure for GitHub API usage.</param>
    /// <param name="appName">The name of the application, used as the User-Agent header value.</param>
    protected override void InitializeClient(HttpClient client, string appName)
    {
        client.DefaultRequestHeaders.Add("User-Agent", appName);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    protected override string? AuthenticationTestUrl => null;



    //    https://polarion.elektrobit.com/polarion/		sdk/doc/rest/changes.txt
    //=>  https://polarion.elektrobit.com/polarion/sdk/doc/rest/changes.txt			OK

    //https://polarion.elektrobit.com/polarion/		/sdk/doc/rest/changes.txt
    //=>  https://polarion.elektrobit.com/sdk/doc/rest/changes.txt					Wrong

    //https://polarion.elektrobit.com/polarion		sdk/doc/rest/changes.txt
    //=>  https://polarion.elektrobit.com/sdk/doc/rest/changes.txt					Wrong

    //https://polarion.elektrobit.com/polarion		/sdk/doc/rest/changes.txt
    //=>  'https://polarion.elektrobit.com/sdk/doc/rest/changes.txt					Wrong



    public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        //https://polarion.elektrobit.com/polarion/sdk/doc/rest/changes.txt

        var text = await GetStringAsync("sdk/doc/rest/changes.txt", cancellationToken);

        if (string.IsNullOrEmpty(text))
            return "0.0.0";

        var match = VersionStringRegex().Match(text);
        return match.Success ? match.Groups[1].Value : "0.0.0";
        
    }

    [GeneratedRegex(@"Version\s+([0-9]+(?:\.[0-9]+)*)")]
    private static partial Regex VersionStringRegex();

    /*
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

    */
}
