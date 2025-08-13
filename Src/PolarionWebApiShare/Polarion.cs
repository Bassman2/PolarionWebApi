namespace PolarionWebApi;

public sealed class Polarion : IDisposable
{
    private PolarionService? service;

    public Polarion(string storeKey, string appName)
       : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
    { }

    public Polarion(Uri host, string token, string appName)
    {
        service = new PolarionService(host, new BearerAuthenticator(token), appName);
    }

    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    public async Task<IEnumerable<Project>?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetProjectsAsync(cancellationToken);
        return res?.Data.CastModel<Project>();
    }

    public async Task<Project?> GetProjectAsync(string projectId, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId)); 

        var res = await service.GetProjectAsync(projectId, cancellationToken);
        return res?.Data.CastModel<Project>();
    }

    public async Task<Project?> GetCollectionsAsync(string projectId, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));

        var res = await service.GetCollectionsAsync(projectId, cancellationToken);
        return res.CastModel<Project>();
    }

    public async Task<IEnumerable<Workitem>?> GetWorkitemsAsync(string projectId, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));

        var res = await service.GetWorkitemsAsync(projectId, cancellationToken);
        return res?.Data.CastModel<Workitem>();
    }

    public async Task<Workitem?> GetWorkitemAsync(string projectId, string workitemId, CancellationToken cancellationToken)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId, nameof(projectId));
        ArgumentNullException.ThrowIfNullOrEmpty(workitemId, nameof(workitemId));

        var res = await service.GetWorkitemAsync(projectId, workitemId, cancellationToken);
        return res?.Data.CastModel<Workitem>();
    }
}
