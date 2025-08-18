namespace PolarionWebApi;

public class Attributes
{
    internal Attributes(AttributesModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    public string Id { get; }

    public string Name { get; }
}
