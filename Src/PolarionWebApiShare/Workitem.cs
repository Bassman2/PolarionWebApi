namespace PolarionWebApi;

public class Workitem
{
    internal Workitem(WorkitemModel model)
    {
        Id = model.Attributes.Id;
        Type = model.Attributes.Type;
        
    }

    public string Id { get; } = null!;

    public string? Type { get; }
}
