namespace PolarionWebApi.Service.Model;

internal class DataModel
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public AttributesModel Attributes { get; set; } = null!;

    [JsonPropertyName("links")]
    public LinksModel Links { get; set; } = null!;
}
