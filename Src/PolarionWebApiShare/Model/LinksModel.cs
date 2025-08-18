namespace PolarionWebApi.Model;

internal class LinksModel
{
    [JsonPropertyName("self")]
    public string Self { get; set; } = null!;

    [JsonPropertyName("first")]
    public string? First { get; set; }


    [JsonPropertyName("next")]
    public string? Next { get; set; }


    [JsonPropertyName("last")]
    public string? Last { get; set; }


    [JsonPropertyName("portal")]
    public string? Portal { get; set; }
}
