namespace PolarionWebApi.Service.Model;

internal class ResponseItemModel
{
    [JsonPropertyName("links")]
    public LinksModel? Links { get; set; }

    [JsonPropertyName("data")]
    public DataModel? Data { get; set; }
}

internal class ResponseListModel
{
    [JsonPropertyName("meta")]
    public MetaModel? Meta { get; set; }

    [JsonPropertyName("links")]
    public LinksModel? Links { get; set; }

    [JsonPropertyName("data")]
    public List<DataModel>? Data { get; set; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ProjectModel), typeDiscriminator: "projects")]
[JsonDerivedType(typeof(TestrunModel), typeDiscriminator: "testruns")]
[JsonDerivedType(typeof(PlanModel), typeDiscriminator: "plans")]
[DebuggerDisplay("{Id}")]
internal class DataModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public AttributesModel Attributes { get; set; } = null!;

    [JsonPropertyName("links")]
    public LinksModel Links { get; set; } = null!;
}