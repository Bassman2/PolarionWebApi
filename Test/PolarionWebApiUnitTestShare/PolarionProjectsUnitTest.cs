namespace PolarionWebApiUnitTest;

[TestClass]
public class PolarionProjectsUnitTest : PolarionBaseUnitTest
{
    //[TestMethod]
    //public async Task TestMethodGetProjectsAsync()
    //{
    //    using var polarion = new Polarion(storeKey, appName);

    //    var list = await polarion.GetProjectsAsync();
    //}

    [TestMethod]
    public async Task TestMethodGetProjectAsync()
    {
        using var polarion = new Polarion(storeKey, appName);

        var item = await polarion.GetProjectAsync(projectId);

        Assert.IsNotNull(item, nameof(item));
        Assert.IsNotNull(item.Links, nameof(item.Links));
        Assert.IsNotNull(item.Data, nameof(item.Data));
        Assert.IsNotNull(item.Data.Attributes, nameof(item.Data.Attributes));

        Assert.AreEqual(polarionHost + "rest/v1/projects/" + projectId, item.Links.Self, nameof(item.Links.Self));
        Assert.AreEqual("projects", item.Data.Type, nameof(item.Data.Type));
        Assert.AreEqual(projectId, item.Data.Id, nameof(item.Data.Id));

        Assert.AreEqual(projectId, item.Data.Attributes.Id, nameof(item.Data.Attributes.Id));
        Assert.AreEqual(projectName, item.Data.Attributes.Name, nameof(item.Data.Attributes.Name));

        Assert.AreEqual(polarionHost + "rest/v1/projects/" + projectId, item.Data.Links.Self, nameof(item.Data.Links.Self));

    }
}
