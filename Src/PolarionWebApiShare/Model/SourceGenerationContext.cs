namespace PolarionWebApi.Model;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(ResponseItemModel))]
[JsonSerializable(typeof(ResponseListModel))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
