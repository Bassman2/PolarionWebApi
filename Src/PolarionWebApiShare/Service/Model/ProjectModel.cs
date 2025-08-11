namespace PolarionWebApi.Service.Model;

internal class ProjectModel
{
    [JsonPropertyName("links")]
    public LinksModel? Links { get; set; }

    [JsonPropertyName("data")]
    public DataModel? Data { get; set; }
}
