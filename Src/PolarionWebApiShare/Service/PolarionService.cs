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
}
