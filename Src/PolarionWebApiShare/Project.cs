namespace PolarionWebApi;

public class Project
{
    internal Project(ProjectModel model)
    {
        Id = model.Attributes.Id;
        Name = model.Attributes.Name;
        Start = model.Attributes.Start;
        TrackerPrefix = model.Attributes.TrackerPrefix;
        Icon = model.Attributes.Icon;
        Color = model.Attributes.Color;
    }

    public string Id { get; } = null!;

    public string? Name { get; }

    public string? Start { get; }

    public string? TrackerPrefix { get; }

    public string? Icon { get; }

    public string? Color { get; }
}
