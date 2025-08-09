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
}
