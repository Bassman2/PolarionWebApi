namespace PolarionWebApi;

public class Project
{
    internal Project(ProjectModel model)
    {
        Links = model.Links.CastModel<Links>()!;
        Data = model.Data.CastModel<Data>()!;
    }

    public Links Links { get; } = null!;

    public Data Data { get; } = null!;
}
