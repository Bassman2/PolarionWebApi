namespace PolarionWebApi.Service.Model;

[JsonSourceGenerationOptions(
    JsonSerializerDefaults.Web,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]

[JsonSerializable(typeof(string))]

internal partial class SourceGenerationContext : JsonSerializerContext
{
}
