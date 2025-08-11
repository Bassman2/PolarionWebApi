namespace PolarionWebApi;

public class Links
{
    internal Links(LinksModel model)
    {
        Self = model.Self;
    }

    public string Self { get; }
}
