namespace PolarionWebApi.Service.Model;

[JsonSourceGenerationOptions(
    JsonSerializerDefaults.Web,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]

[JsonSerializable(typeof(IEnumerable<ProjectModel>))]

internal partial class SourceGenerationContext : JsonSerializerContext
{
}
