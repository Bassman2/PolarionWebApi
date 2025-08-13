namespace PolarionWebApi.Service.Model;

internal class AttributesModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("active")]
    public bool Active { get; set; } 

    [JsonPropertyName("start")]
    public string? Start { get; set; }

    [JsonPropertyName("trackerPrefix")]
    public string? TrackerPrefix { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; } = null!;
}
